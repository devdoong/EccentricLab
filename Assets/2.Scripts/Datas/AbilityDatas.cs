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

    public SkillData(float damage, float damagePerLevel, string description, string levelUpDescription)
    { //���۱⺻������ , �������� ������ ��·� , ��ų����, �������� ��ų����
        Damage = damage;
        DamagePerLevel = damagePerLevel;
        Description = description;
        LevelUpDescription = levelUpDescription;
    }
}
public class AbilityDatas
{
    public Dictionary<string, SkillData> dic_skillData = new Dictionary<string, SkillData>();
    public void Init()
    {
        dic_skillData["HP"] =

            new SkillData(
                100,
                20,
                "",
                "ü�� ����"
                );

        dic_skillData["Arrow"] = 

            new SkillData(
                30, 
                15, 
                "������ ȭ���� �߻��մϴ�", 
                "ȭ�� ������ ����");

        dic_skillData["RotationalSolid"] = 

            new SkillData(
            15, 
            7.5f, 
            "�ֺ��� ȸ���ϸ� ���� �����ϴ� �ٶ�", 
            "ȸ�� ���� ����");

        dic_skillData["Hawk"] = 

            new SkillData(
                20, 
                10, 
                "���� ���ƴٴϸ� ���� �����ϴ� ��", 
                "�Ѹ��� �� �߰�");
    }

}
