using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Animator shoot_animator;

    private void Awake()
    {
        shoot_animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        Debug.Log("애니메이션 종료");
    }

}
