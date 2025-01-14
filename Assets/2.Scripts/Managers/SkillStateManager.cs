using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillStateManager
{

    private readonly int MaxSkillLevel = 5;
    private Dictionary<string,float> abilityState = new Dictionary<string,float>();
    private Dictionary<string,int> abilityLevelState = new Dictionary<string, int>();
    public void Init()
    {
        foreach (var skilldata in Managers.AbilityDatas.skillData)
        {
            Debug.Log(skilldata);
            abilityState[skilldata.Key] = skilldata.Value.Damage;
            abilityLevelState[skilldata.Key] = 0;
        }
    }
    public float GetDamage(string name)
    {
        name = name.Replace("(Clone)", "");
        Debug.Log(abilityState[name]);
        return abilityState[name];
    }

    public bool AbilitySelected_LevelUp(string name)
    {
        name = name.Replace("(Clone)", "");
        abilityState[name] += Managers.AbilityDatas.skillData[name].DamagePerLevel;

        if (abilityLevelState[name] < MaxSkillLevel)
        {
            abilityLevelState[name]++;
            return false;
        }
        else return true; //해당 스킬의 레벨 획득이 최대치라면
    }

}
