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

    private void Start()
    {
        arrowPrefab = Resources.Load<GameObject>("4.Prefabs/Projectiles/Arrow");
        if (arrowPrefab == null) Debug.Log("Arrow 프리팹 Missing");


        shootPoint = transform.Find("ArrowShootPoint");
        if (shootPoint == null) Debug.Log("shootPoint Missing!!!");
    }

    void Update()
    {

        #region 플레이어 이동 로직
        float horizontal = Input.GetAxis("Horizontal"); // 수평 입력
        float vertical = Input.GetAxis("Vertical"); // 수직 입력

        m_Movement = new Vector3(horizontal, 0, vertical).normalized; //벡터 정규화

        transform.position += m_Movement * moveSpeed * Time.deltaTime;
        #endregion

        #region 적 바라보는 로직
        GameObject closeEnemy = GetCloseEnemy();
        if (closeEnemy != null)
        {
            Vector3 dir = (closeEnemy.transform.position - transform.position).normalized;
            Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
        }
        #endregion

        
    }

    #region 타겟 Enemy 서칭
    GameObject GetCloseEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); //Enemy 태그 전체 검사

        if (enemys.Length == 0) return null;

        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemys)
        {
            float distance = Vector3.Distance(transform.position,enemy.transform.position);
            if (distance < closestDistance)
            {
                closest = enemy;
                closestDistance = distance;
            }
        }
        return closest;
    }
    #endregion
}
