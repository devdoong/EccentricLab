using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkill
{
    System.Random random = new System.Random(); //���� ���
    List<string> list_keys = new List<string>();
    int get_count = 0;

    public void Init()
    {
        #region ��ųʸ� ��ų���� Ű���� ��� List���ٰ� ����
        list_keys.Clear();

        //��ųʸ� ��ų���� Ű���� ��� List���ٰ� ����
        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            list_keys.Add(skill.Key);
        }
        //Debug.Log($"{list_keys.Count} keys"); //����Ʈ�� �� ����Ǿ����� Ȯ��
        #endregion
    }

    public string GetRandomKey()
    {
        if (list_keys.Count == 0)
            return null;

        //��ü ��ų ����Ʈ���� �����Ͽ� ��ȯ.
        string key = list_keys[random.Next(list_keys.Count)];

        //ȹ���� ��ų�� ������ ���� �ƴ���
        if (Managers.SkillState.abilityLevelState[key] >= 5)
        {
            list_keys.Remove(key); //�����̴ϱ� ����Ʈ���� ����
            Debug.Log(list_keys.Count);
            get_count++;
            return null;
        }

        Debug.Log(list_keys.Count);
        list_keys.Remove(key);//� �ϳ��� ��ư�� ���������ϱ� ��ø���� �ʵ��� ����
        get_count++;

        if (get_count == 3) //��ư������ ��� �������ٸ�
        {
            Init();
            get_count = 0;
        }
        Debug.Log("count:"+get_count);    
        return key; //5���� ������ ��ȯ

    }
}

