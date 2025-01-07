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
        #region �˹��� ���� �÷��̾�� ������ �Ͻ������ϰ� �˹��� �̷���� �ð� üũ
        if (isMoveBack == true)
        {
            moveback_timer += Time.deltaTime; //����� Ÿ�̸� ����
            transform.position = Vector3.MoveTowards(transform.position, transform.position+(new Vector3(0,3,0)), 3 * Time.deltaTime);

            if (moveback_timer >= 1.0f) //�˹� ���ӽð� ����������
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
            Debug.Log("�÷��̾� �浹 �߻�");
            Transform player_transform = collision.transform;

            Vector3 opDirection = -player_transform.position; //������ �ݴ�������� �и�����

            isMoveBack = true;
            
        }
    }

}
