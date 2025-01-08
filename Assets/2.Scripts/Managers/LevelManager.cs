using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    private float level = 1; public float Level => level;
    private float maxExp = 100; public float MaxExp => maxExp;
    private float myExp = 0; public float MyExp => myExp;
    private float expIncrease = 30; public float ExpIncrease => expIncrease;
    private float maxlevel = 30; public float MaxLevel => maxlevel;

    public void levelUp()
    {
        if (level >= maxlevel)
        {
            maxLevel();
            return;
        }
        this.level++;
        this.myExp = 0;
        this.maxExp += this.expIncrease;
    }
    public void getExp(float exp_amount)
    {
        this.myExp += exp_amount;
        if(this.myExp >= this.maxExp)
        {
            levelUp();
        }
    }

    public void maxLevel()
    {
        if (this.level >= this.maxlevel)
        {
            this.level = this.maxlevel;
        }
    }


}
