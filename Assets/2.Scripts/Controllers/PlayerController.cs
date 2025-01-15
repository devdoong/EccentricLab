using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;



public class PlayerController : MonoBehaviour
{
    #region 플레이어 이동에 필요한 변수
    public float moveSpeed = 5.0f; 
    public float turnSpeed = 10.0f;
    static public Vector3 m_Movement;
    #endregion

    #region 화살 발사에 필요한 변수
    private GameObject arrowPrefab;
    private Transform shootPoint;
    #endregion

    public GameObject closeEnemy;
    void Update()
    {

        #region 플레이어 이동 로직
        float horizontal = Input.GetAxis("Horizontal"); // 수평 입력
        float vertical = Input.GetAxis("Vertical"); // 수직 입력

        m_Movement = new Vector3(horizontal, 0, vertical).normalized; //벡터 정규화

        transform.position += m_Movement * moveSpeed * Time.deltaTime;
        #endregion

        #region 적 바라보는 로직
        closeEnemy = Managers.closeEnemy;
        if (closeEnemy != null)
        {
            Vector3 dir = (closeEnemy.transform.position - transform.position).normalized; //바라봐야할 방향
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up); //그 방향으로 돌리기 위한 쿼터니언.
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
        #endregion

        
    }

}
