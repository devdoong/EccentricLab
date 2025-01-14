using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkill
{
    public string[] GetRandomKey()
    {
        Debug.Log("========GetRandomKey========");

        List<string> _returnKeys = new List<string>();
        List<string> list_keys = new List<string>();

        #region Ű��(string)�� LIST���·� ������
        //��ųʸ� Ű���� List���ٰ� ����
        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            list_keys.Add(skill.Key); 
        }
        //Debug.Log($"{list_keys.Count} keys"); //����Ʈ�� �� ����Ǿ����� Ȯ��
        #endregion

        System.Random random = new System.Random(); //���� ���
        //Debug.Log("3:    "+ list_keys[random.Next(list_keys.Count)]); //���� ���

        //Debug.Log(_returnKeys.Count >= 3);
        while (_returnKeys.Count < 3)
        {
            string key = list_keys[random.Next(list_keys.Count)]; //List�� ���������� ������ ���� key�� ��ȯ

            if (Managers.SkillState.abilityLevelState[key] < 5 /*5= �ִ� ��ų���� */)
            {
                if(_returnKeys.Contains(key))
                    continue;
                _returnKeys.Add(key);
                Debug.Log(_returnKeys);
            }
        }
        //Debug.Log(_returnKeys.Count);


        return _returnKeys.ToArray();
    }

}
