using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectButton : MonoBehaviour
{


    private Image icon;
    private Text text_level; private int level;
    private Text[] get_component; //자식에서 텍스트 컴포넌트 가져오는 용도
    string random_skill_name;
    public static bool AllMax = false;


    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];//본인의 Image도 포함되기 때문에 [1]을 줌
        get_component = GetComponentsInChildren<Text>(); //텍스트 컴포넌트 초기화
        text_level = get_component[0]; //초기화한 컴포넌트 사용할 변수에 한번 더 초기화
    }

    void OnEnable()
    {
        random_skill_name = Managers.RandomSkill.GetRandomKey(); //랜덤 스킬 받아옴
        if (transform.name == "3")
        {
            Debug.Log("transform : " + transform.name);
            transform.gameObject.SetActive(AllMax);
            Debug.Log(AllMax);
            return;
        }
        if (random_skill_name == null && transform.name != "3") //다가져가고 남는게 없을경우에
        {
            gameObject.SetActive(false); //이 버튼은 꺼줌
            return;
        }
        icon.sprite = Managers.AbilityDatas.dic_skillData[random_skill_name].icon_sprite;
        level = Managers.SkillState.abilityLevelState[random_skill_name];
        text_level.text = "Level: " + level.ToString();

    }


    public void Click()
    {
        Managers.SkillState.abilityLevelState[random_skill_name]++;
        GameObject levelUp = Managers.Instance.Find_GO("LevelUp");
        Time.timeScale = 1f;
        SkillUpgrade(random_skill_name);
        levelUp.SetActive(false);
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
        Debug.Log("여기까지 내려옴");
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
