using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager
{
    private float level = 1; public float Level => level;
    private float exp = 100; public float EXP => exp;
    private float myexp = 0; public float MyExp => myexp;
    private float expIncrease = 30; public float ExpIncrease => expIncrease;
    private float maxlevel = 30; public float MaxLevel => maxlevel;
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
