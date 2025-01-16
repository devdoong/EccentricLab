using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager
{
    public  float _HP =100; public float HP => _HP;
    private float _MaxHP =100; public float MaxHP => _MaxHP;
    private float _hpIncrease = 50; public float HPIncrease => _hpIncrease;

    public float OnDamaged(float damage)
    {
        this._HP -= damage;
        return this._HP;
    }

    public float Heal()
    {
        _HP = _MaxHP;
        return this._HP;
    }

    public float MaxUP()
    {
        _MaxHP += _hpIncrease;
        return this._HP;
    }
}
