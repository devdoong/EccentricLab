using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gem : MonoBehaviour
{
    private SphereCollider gemcollider;
    private Rigidbody gem_rigidbody;
    private bool getting = false;
    private bool isMoveBack = false;
    private float moveback_timer= 0f;
    private bool gotoPlayer = false;
    private GameObject Player;
    public float speed = 20.0f;
    

    [SerializeField]
    private float magnetRadius=1.8f;

    // Start is called before the first frame update
    void Start()
    {
        gemcollider = GetComponent<SphereCollider>();
        gem_rigidbody = GetComponent<Rigidbody>();
        gemcollider.radius = magnetRadius;
        Player = GameObject.Find("BasicArcher");
    }

    private void Update()
    {
        #region 넉백을 위해 플레이어에게 전진을 일시정지하고 넉백이 이루어질 시간 체크
        if (isMoveBack == true)
        {
            moveback_timer += Time.deltaTime; //무브백 타이머 증가
            transform.position = Vector3.MoveTowards(transform.position, transform.position+(new Vector3(0,3,0)), 3 * Time.deltaTime);

            if (moveback_timer >= 1.0f) //넉백 지속시간 충족했으면
            {
                isMoveBack = false;
                moveback_timer = 0;
                gotoPlayer = true;
            }
        }
        #endregion

        if (gotoPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

            if (transform.position == Player.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && getting == false)
        {
            getting = true;
            Debug.Log("플레이어 충돌 발생");
            Transform player_transform = collision.transform;

            Vector3 opDirection = -player_transform.position; //보석이 반대방향으로 밀리도록

            isMoveBack = true;
            
        }
    }

}
