using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillData
{
    public float Damage; //���� �⺻ ������
    public float DamagePerLevel; //�������� ������ ��·�
    public string Description; //����
    public string LevelUpDescription;
    public Sprite icon_sprite;


    public SkillData(float damage, float damagePerLevel, string description, string levelUpDescription, Sprite icon)
    { //���۱⺻������ , �������� ������ ��·� , ��ų����, �������� ��ų����
        Damage = damage;
        DamagePerLevel = damagePerLevel;
        Description = description;
        LevelUpDescription = levelUpDescription;
        this.icon_sprite = icon;
    }
}
public class AbilityDatas
{

   /* private Sprite[] sprites;

    AbilityDatas(Sprite[] sprites)
    {
        this.sprites = sprites;
    }*/
    
    public Dictionary<string, SkillData> dic_skillData = new Dictionary<string, SkillData>();
    public void Init()
    {
        dic_skillData["HP"] =

            new SkillData(
                100,
                20,
                "",
                "ü�� ����",
                Managers.Instance.sprites[0]
                );

        dic_skillData["Arrow"] = 

            new SkillData(
                30, 
                15, 
                "������ ȭ���� �߻��մϴ�", 
                "ȭ�� ������ ����",
                Managers.Instance.sprites[1]

                );

        dic_skillData["RotationalSolid"] = 

            new SkillData(
            15, 
            7.5f, 
            "�ֺ��� ȸ���ϸ� ���� �����ϴ� �ٶ�", 
            "ȸ�� ���� ����",
            Managers.Instance.sprites[2]

            );

        dic_skillData["Hawk"] = 

            new SkillData(
                20, 
                10, 
                "���� ���ƴٴϸ� ���� �����ϴ� ��", 
                "�Ѹ��� �� �߰�",
                Managers.Instance.sprites[3]
                );
    }

}
