using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectButton : MonoBehaviour
{


    private Image icon;
    private Text text_level; private int level;
    private Text[] get_component; //�ڽĿ��� �ؽ�Ʈ ������Ʈ �������� �뵵
    string random_skill_name;



    private void Awake()
    {
        icon = GetComponentsInChildren<Image>()[1];//������ Image�� ���ԵǱ� ������ [1]�� ��
        get_component = GetComponentsInChildren<Text>(); //�ؽ�Ʈ ������Ʈ �ʱ�ȭ
        text_level = get_component[0]; //�ʱ�ȭ�� ������Ʈ ����� ������ �ѹ� �� �ʱ�ȭ
    }

    void OnEnable()
    {
        random_skill_name = Managers.RandomSkill.GetRandomKey(); //���� ��ų �޾ƿ�
        if(random_skill_name == null)
        {
            gameObject.SetActive(false);
            return;
        }

        icon.sprite = Managers.AbilityDatas.dic_skillData[random_skill_name].icon_sprite;
        level = Managers.SkillState.abilityLevelState[random_skill_name];
        text_level.text = "Level: "+level.ToString();
    }


    public void Click()
    {
        Managers.SkillState.abilityLevelState[random_skill_name]++;
    }

}
