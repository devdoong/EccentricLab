using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkill
{
    System.Random random = new System.Random(); //���� ���
    public List<string> list_keys = new List<string>();
    public bool ALLMAX = false;

    public void Init()
    {
        #region ��ųʸ� ��ų���� Ű���� ��� List���ٰ� ����
        list_keys.Clear();

        //��ųʸ� ��ų���� Ű���� ��� List���ٰ� ����
        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            //������ ������ ����
            if(Managers.SkillState.abilityLevelState[skill.Key] < 5)
            {
                list_keys.Add(skill.Key);
            }
        }

        if (list_keys.Count == 0)
        {
            Debug.Log("���δ� �����Դϴ�");

        }
        #endregion
    }

    public string GetRandomKey()
    {
        if (list_keys.Count == 0)
            return null;

        //��ü ��ų ����Ʈ���� �����Ͽ� ��ȯ.
        string key = list_keys[random.Next(list_keys.Count)];

        //���������� ����
        list_keys.Remove(key);
        Debug.Log(list_keys.Count); 
        

        return key;

        

    }
}

