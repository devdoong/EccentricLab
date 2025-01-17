using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager
{
    private float level = 1; public float Level => level;
    private float maxExp = 30; public float MaxExp => maxExp;
    private float myExp = 0; public float MyExp => myExp;
    private float expIncrease = 30; public float ExpIncrease => expIncrease;
    private float maxlevel = 30; public float MaxLevel => maxlevel;


    public void levelUp()
    {
        GameObject levelUp = Managers.Instance.Find_GO("LevelUp");
        Time.timeScale = 0f;


        //레벨(경험치)가 최대라면
        if (level >= maxlevel) 
        {
            maxLevel();
            levelUp.SetActive(true);
        }

        else if ( level < maxlevel )
        {
            this.level++;
            this.myExp = 0;
            this.maxExp += this.expIncrease;
            levelUp.SetActive(true);

        }
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
