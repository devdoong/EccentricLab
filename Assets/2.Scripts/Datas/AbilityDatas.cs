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
    public Dictionary<string, SkillData> skillData = new Dictionary<string, SkillData>();
    public void Init()
    {
        skillData["HP"] =

            new SkillData(
                100,
                20,
                "",
                "ü�� ����"
                );

        skillData["Arrow"] = 

            new SkillData(
                30, 
                15, 
                "������ ȭ���� �߻��մϴ�", 
                "ȭ�� ������ ����");

        skillData["RotationalSolid"] = 

            new SkillData(
            15, 
            7.5f, 
            "�ֺ��� ȸ���ϸ� ���� �����ϴ� �ٶ�", 
            "ȸ�� ���� ����");

        skillData["Hawk"] = 

            new SkillData(
                20, 
                10, 
                "���� ���ƴٴϸ� ���� �����ϴ� ��", 
                "�Ѹ��� �� �߰�");
    }

}
