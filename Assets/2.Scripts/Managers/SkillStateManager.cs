using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillStateManager
{

    public readonly int MaxSkillLevel = 5;
    public Dictionary<string,float> abilityState = new Dictionary<string,float>(); //Value : ���� ��ų ������
    public Dictionary<string,int> abilityLevelState = new Dictionary<string, int>(); //Value : ���� ��ų ����

    public void Init() //
    {
        foreach (var skilldata in Managers.AbilityDatas.dic_skillData) //��ü ��ų���� ��ȸ�ϸ鼭
        {
            //Debug.Log(skilldata);
            abilityState[skilldata.Key] = skilldata.Value.Damage; //
            abilityLevelState[skilldata.Key] = 0;
        }
    }
    public float GetDamage(string name) //������ ��ȯ
    {
        name = name.Replace("(Clone)", "");
        return abilityState[name]; //������ ��ȯ
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
        else return true; //�ش� ��ų�� ���� ȹ���� �ִ�ġ���
    }

}
