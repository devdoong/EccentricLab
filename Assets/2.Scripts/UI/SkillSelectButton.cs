using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectButton : MonoBehaviour
{


    public Image icon;
    public Text text_level; private int level;
    public Text[] get_component; //자식에서 텍스트 컴포넌트 가져오는 용도
    public string random_skill_name;
    public bool btn_state = true;


    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];//본인의 Image도 포함되기 때문에 [1]을 줌
        get_component = GetComponentsInChildren<Text>(); //텍스트 컴포넌트 초기화
        text_level = get_component[0]; //초기화한 컴포넌트 사용할 변수에 한번 더 초기화
    }

    private void OnDisable()
    {
        Debug.Log(transform.name + ": OFF!!!!!");

    }

    public void Click()
    {
        SkillUpgrade(Managers.Instance.Skill_Selected(transform.name));

        
    }

    public void HealClick()
    {
        Managers.HP.Heal();
        GameObject levelUp = Managers.Instance.Find_GO("LevelUp");
        Time.timeScale = 1f;
        levelUp.SetActive(false);
    }

    private void SkillUpgrade(string random_skill_name)
    {
        switch (random_skill_name)
        {
            case "HP":
                CallHP();
                break;
            case "Arrow":
                break;
            case "RotationalSolid":
                CallRotationalSolid();
                break;
            case "Hawk":
                CallHawk();
                break;
            default:
                Debug.LogError("업그레이드 등록이 안된 스킬입니다.");
                break;

        }
    }

    private void CallHP()
    {
        Managers.HP.MaxUP();
    }

    private void CallArrow()
    {
        //필요없음
    }

    private void CallRotationalSolid() //이 함수는 외부 클래스에 존재해
    {
        GameObject go = Managers.Instance.Find_GO("RotationalSolid");
        if (go == null) { Debug.Log(" RotationalSolid오브젝트 발견 못함"); }


        if (Managers.SkillState.abilityLevelState["RotationalSolid"] == 1)
        {
            go.SetActive(true);
            return;
        }
        Managers.SkillState.specialState["RotationalSolid"] += Managers.AbilityDatas.dic_skillData["RotationalSolid"].SpecialValuePerLevel;
        go.SetActive(false);
        go.SetActive(true); //해당 오브젝트의 OnEnable에 회전속도 초기화가 들어있음
    }
    private void CallHawk()
    {
        GameObject go = Managers.Instance.Find_GO("Hawk");
        GameObject RePositioning;
        if (go == null) { Debug.Log(" Hawk 발견 못함"); }


        if (Managers.SkillState.abilityLevelState["Hawk"] == 1)
        {
            go.SetActive(true);
            return;
        }

        RePositioning=Instantiate(go);
        RePositioning.transform.position = new Vector3(Managers.Player.position.x, 1.3f, Managers.Player.position.z);
    }

}
