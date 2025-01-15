using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalSolid : MonoBehaviour
{
    public int howmany_Solid = 3;
    public Vector3 rotationSpeed = new Vector3(0, 30, 0);
    void Update()
    {
        transform.position = Managers.Player.transform.position;
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
