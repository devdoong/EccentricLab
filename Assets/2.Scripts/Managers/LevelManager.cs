using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    private int level = 1; public int Level => level;
    private int exp = 100; public int EXP => exp;
    private int myexp = 0; public int MyExp => myexp;
    private int expIncrease = 30; public int ExpIncrease => expIncrease;
    private int maxlevel = 30; public int MaxLevel => maxlevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void levelUp()
    {
        if (level == maxlevel) return;
        this.level++;
        this.myexp = 0;
        this.exp += expIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
