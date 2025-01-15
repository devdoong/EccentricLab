using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkill
{
    System.Random random = new System.Random(); //랜덤 사용
    public List<string> list_keys = new List<string>();
    public bool ALLMAX = false;

    public void Init()
    {
        #region 딕셔너리 스킬들의 키값을 모두 List에다가 저장
        list_keys.Clear();

        //딕셔너리 스킬들의 키값을 모두 List에다가 저장
        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            //하지만 만랩은 제외
            if(Managers.SkillState.abilityLevelState[skill.Key] < 5)
            {
                list_keys.Add(skill.Key);
            }
        }

        if (list_keys.Count == 0)
        {
            Debug.Log("전부다 만랩입니다");

        }
        #endregion
    }

    public string GetRandomKey()
    {
        if (list_keys.Count == 0)
            return null;

        //전체 스킬 리스트에서 랜덤하여 반환.
        string key = list_keys[random.Next(list_keys.Count)];

        //가져갔으면 지움
        list_keys.Remove(key);
        Debug.Log(list_keys.Count); 
        

        return key;

        

    }
}

