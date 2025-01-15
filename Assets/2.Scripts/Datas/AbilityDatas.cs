using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillData
{
    public float Damage; //시작 기본 데미지
    public float DamagePerLevel; //레벨업당 데미지 상승량
    public string Description; //설명
    public string LevelUpDescription;
    public Sprite icon_sprite;


    public SkillData(float damage, float damagePerLevel, string description, string levelUpDescription, Sprite icon)
    { //시작기본데미지 , 레벨업당 데미지 상승량 , 스킬설명, 레벨업시 스킬설명
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
                "체력 증가",
                Managers.Instance.sprites[0]
                );

        dic_skillData["Arrow"] = 

            new SkillData(
                30, 
                15, 
                "적에게 화살을 발사합니다", 
                "화살 데미지 증가",
                Managers.Instance.sprites[1]

                );

        dic_skillData["RotationalSolid"] = 

            new SkillData(
            15, 
            7.5f, 
            "주변을 회전하며 적을 공격하는 바람", 
            "회전 갯수 증가",
            Managers.Instance.sprites[2]

            );

        dic_skillData["Hawk"] = 

            new SkillData(
                20, 
                10, 
                "맵을 돌아다니며 적을 공격하는 매", 
                "한마리 더 추가",
                Managers.Instance.sprites[3]
                );
    }

}
