using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager
{
    private int _HP=100; public int HP => _HP;
    private int _MaxHP=100; public int MaxHP => _MaxHP;
    private int _hpIncrease = 50; public int HPIncrease => _hpIncrease;

    public int OnDamaged(int damage)
    {
        this._HP -= damage;
        return this._HP;
    }

    public int Heal()
    {
        _HP = _MaxHP;
        return this._HP;
    }

    public int MaxUP()
    {
        _MaxHP += _hpIncrease;
        return this._HP;
    }
}
