using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkill
{
    System.Random random = new System.Random(); //랜덤 사용
    List<string> list_keys = new List<string>();
    int get_count = 0;

    public void Init()
    {
        #region 딕셔너리 스킬들의 키값을 모두 List에다가 저장
        list_keys.Clear();

        //딕셔너리 스킬들의 키값을 모두 List에다가 저장
        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            list_keys.Add(skill.Key);
        }
        //Debug.Log($"{list_keys.Count} keys"); //리스트에 잘 저장되었는지 확인
        #endregion
    }

    public string GetRandomKey()
    {
        if (list_keys.Count == 0)
            return null;

        //전체 스킬 리스트에서 랜덤하여 반환.
        string key = list_keys[random.Next(list_keys.Count)];

        //획득한 스킬이 만랩이 인지 아닌지
        if (Managers.SkillState.abilityLevelState[key] >= 5)
        {
            list_keys.Remove(key); //만랩이니까 리스트에서 제외
            Debug.Log(list_keys.Count);
            get_count++;
            return null;
        }

        Debug.Log(list_keys.Count);
        list_keys.Remove(key);//어떤 하나의 버튼이 가져갔으니까 중첩되지 않도록 삭제
        get_count++;

        if (get_count == 3) //버튼세개가 모두 가져갔다면
        {
            Init();
            get_count = 0;
        }
        Debug.Log("count:"+get_count);    
        return key; //5보다 낮으면 반환

    }
}

