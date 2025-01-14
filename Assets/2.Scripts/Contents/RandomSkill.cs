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

        #region 키값(string)을 LIST형태로 재저장
        //딕셔너리 키값을 List에다가 저장
        foreach (var skill in Managers.AbilityDatas.dic_skillData)
        {
            list_keys.Add(skill.Key); 
        }
        //Debug.Log($"{list_keys.Count} keys"); //리스트에 잘 저장되었는지 확인
        #endregion

        System.Random random = new System.Random(); //랜덤 사용
        //Debug.Log("3:    "+ list_keys[random.Next(list_keys.Count)]); //정상 출력

        //Debug.Log(_returnKeys.Count >= 3);
        while (_returnKeys.Count < 3)
        {
            string key = list_keys[random.Next(list_keys.Count)]; //List의 개수내에서 랜덤한 값을 key로 반환

            if (Managers.SkillState.abilityLevelState[key] < 5 /*5= 최대 스킬레벨 */)
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
