using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkill
{
    System.Random random = new System.Random();
    private HashSet<string> usedKeys = new HashSet<string>();

    public string GetRandomKey()
    {
        List<string> list_keys = new List<string>();

        //딕셔너리의 키값들중 (만렙 이하 && 가져간적 없는) 키값을 List에 저장
        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            if (Managers.SkillState.abilityLevelState[skill.Key] < 5 && usedKeys.Contains(skill.Key)==false)
            {
                list_keys.Add(skill.Key);
            }
        }

        //단 하나도 저장된것이 없다면 전부다 만랩이라는것
        if (list_keys.Count == 0)
        {
            Debug.Log("전부다 만랩이거나 사용 가능한 키가 없습니다");
            return null;
        }

        //랜덤값 전달
        string key = list_keys[random.Next(list_keys.Count)];
        usedKeys.Add(key); //중복제거
        return key;
    }

    public void Reset()
    {
        //3버튼 다 가져갔다고 판단되는 경우 호출하고 있음
        usedKeys.Clear();
    }
}
