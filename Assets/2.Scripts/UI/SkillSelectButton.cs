using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectButton : MonoBehaviour
{


    private Image icon;
    private Text text_level; private int level;
    private Text[] get_component; //자식에서 텍스트 컴포넌트 가져오는 용도
    string random_skill_name;



    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];//본인의 Image도 포함되기 때문에 [1]을 줌
        get_component = GetComponentsInChildren<Text>(); //텍스트 컴포넌트 초기화
        text_level = get_component[0]; //초기화한 컴포넌트 사용할 변수에 한번 더 초기화
    }

    void OnEnable()
    {
        random_skill_name = Managers.RandomSkill.GetRandomKey(); //랜덤 스킬 받아옴

        /*while(random_skill_name != null)
        { //만약에 null을 리턴 (만랩스킬을 리턴 받은거라면) 다시 랜덤 받아옴. 
            random_skill_name = Managers.RandomSkill.GetRandomKey(); //랜덤 스킬 3개 불러옴
        }*/

        icon.sprite = Managers.AbilityDatas.dic_skillData[random_skill_name].icon_sprite;
        level = Managers.SkillState.abilityLevelState[random_skill_name];
        text_level.text = "Level: "+level.ToString();

    }

}
