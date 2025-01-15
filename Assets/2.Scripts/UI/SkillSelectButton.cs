using System.Collections;
using System.Collections.Generic;
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

        /*while(random_skill_name != null)
        { //���࿡ null�� ���� (������ų�� ���� �����Ŷ��) �ٽ� ���� �޾ƿ�. 
            random_skill_name = Managers.RandomSkill.GetRandomKey(); //���� ��ų 3�� �ҷ���
        }*/

        icon.sprite = Managers.AbilityDatas.dic_skillData[random_skill_name].icon_sprite;
        level = Managers.SkillState.abilityLevelState[random_skill_name];
        text_level.text = "Level: "+level.ToString();

    }

}
