using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class DamageManager
{
    public Dictionary<string,float>  dic_Damage = new Dictionary<string,float>();
    
    public void Init()
    {
        dic_Damage["Arrow"] = 60;
        dic_Damage["RotationalSolid"] = 30;
    }

    public float GetDamage(string name)
    {
        name = name.Replace("(Clone)", "");
        Debug.Log(name);
        Debug.Log(name + "이 데미지를 입혔습니다 ==> " + dic_Damage[name]);
        return dic_Damage[name];
    }
}
