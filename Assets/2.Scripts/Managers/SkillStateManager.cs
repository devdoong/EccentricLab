using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SkillStateManager
{

    public readonly int MaxSkillLevel = 5;
    public Dictionary<string,float> abilityState = new Dictionary<string,float>(); //Value : 현재 스킬의 값.
    public Dictionary<string,int> abilityLevelState = new Dictionary<string, int>(); //Value : 현재 스킬 레벨
    public Dictionary<string,float> specialState = new Dictionary<string,float>();// Value : 스킬의 색깔에 맞는 상승값.

    public void Init() //
    {
        foreach (var skilldata in Managers.AbilityDatas.dic_skillData) //전체 스킬들을 순회하면서
        {
            abilityState[skilldata.Key] = skilldata.Value.Damage; //데미지값 불러와줌
            abilityLevelState[skilldata.Key] = 0; //모두 0레벨로 시작할것임
            specialState[skilldata.Key] = skilldata.Value.SpecialValue; //스페셜값
        }
    }
    public float GetState(string name) //데미지(스킬수치) 반환
    {
        name = name.Replace("(Clone)", "");
        return abilityState[name]; //데미지(스킬수치) 반환
    }

    public bool AbilitySelected_LevelUp(string name)
    {
        name = name.Replace("(Clone)", "");
        abilityState[name] += Managers.AbilityDatas.dic_skillData[name].DamagePerLevel;

        if (abilityLevelState[name] < MaxSkillLevel)
        {
            abilityLevelState[name]++;
            return false;
        }
        else return true; //해당 스킬의 레벨 획득이 최대치라면
    }

}
