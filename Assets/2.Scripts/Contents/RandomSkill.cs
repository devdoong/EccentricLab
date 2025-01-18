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

        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            if (Managers.SkillState.abilityLevelState[skill.Key] < 5 && !usedKeys.Contains(skill.Key))
            {
                list_keys.Add(skill.Key);
            }
        }

        if (list_keys.Count == 0)
        {
            Debug.Log("전부다 만랩이거나 사용 가능한 키가 없습니다");
            return null;
        }

        string key = list_keys[random.Next(list_keys.Count)];
        usedKeys.Add(key);
        return key;
    }

    public void Reset()
    {
        usedKeys.Clear();
    }
}
