using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
public class GameManager : MonoBehaviour
{
    #region Wall
    public GameObject[] walls = new GameObject[2];
    public Vector3 posWall_Bottom_Left;
    public Vector3 posWall_Top_Right;
    #endregion
    

    void Update()
    {
        #region Wall
        posWall_Bottom_Left = Camera.main.WorldToViewportPoint(transform.position);
        posWall_Top_Right = Camera.main.WorldToViewportPoint(transform.position);

        posWall_Bottom_Left.x = 0f;
        posWall_Bottom_Left.y = 0f;
        posWall_Bottom_Left.z = Camera.main.nearClipPlane + 30f;

        posWall_Top_Right.x = 1f;
        posWall_Top_Right.y = 1f;
        posWall_Top_Right.z = Camera.main.nearClipPlane + 30f; 

        walls[0].transform.position = Camera.main.ViewportToWorldPoint(posWall_Bottom_Left);
        walls[1].transform.position = Camera.main.ViewportToWorldPoint(posWall_Top_Right);

        Vector3 wall0Position = walls[0].transform.position;
        wall0Position.y = 0f;
        walls[0].transform.position = wall0Position;

        Vector3 wall1Position = walls[1].transform.position;
        wall1Position.y = 0f;
        walls[1].transform.position = wall1Position;
        #endregion
    }

}
