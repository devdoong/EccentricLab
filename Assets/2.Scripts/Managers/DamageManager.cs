using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager
{
    public Dictionary<string,float>  dic_Damage = new Dictionary<string,float>();
    
    public void Init()
    {
        dic_Damage["Arrow"] = 60;
        dic_Damage["RotationalSolid"] = 30;
        dic_Damage["Hawk"] = 30;
    }

    public float GetDamage(string name)
    {
        name = name.Replace("(Clone)", "");
        return dic_Damage[name];
    }
}
