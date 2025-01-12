using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region 기본변수
    static Transform player; //플레이어 transform
    public float moveSpeed = 3.0f; //이동 속도
    public float turnSpeed = 20.0f; //rotation하여 돌아보는 속도
    public float backAmount = 1.0f; //넉백되는 시간
    #endregion

    #region 가까이오면 멈추기 용도의 변수
    public bool isCollision = false; //플레이어와 충돌 상태
    public float distance; //플레이어와의 거리차이를 구하여 바로 앞까지 왔다면 이동을 멈추기 위해서.
    public float stop_distance = 0.86f;
    #endregion

    #region 몬스터 체력
    public float HP = 100;
    public float MaxHP = 100;
    #endregion

    #region 넉백을 위한 변수
    private bool isKnockBack = false;
    public float knockBackDuration = 0.2f; // 넉백 지속 시간
    public float knockBackTimer = 0f; // 넉백 타이머
    static Rigidbody enemt_rigidbody;
    Color originalColor; //사용안함
    #endregion

    #region 경험치 드랍에 필요한 변수
    public GameObject gem;
    private GameObject gemParent;
    #endregion

    #region 데미지를 주기 위한 변수
    public float damage = 1;
    public float damage_Timer = 0f;
    public float damage_delayTime = 0.3f;
    #endregion

    private void Start()
    {
        player = GameObject.Find("BasicArcher").transform;
        enemt_rigidbody = GetComponent<Rigidbody>();
        gemParent = GameObject.Find("@Gems");
        if (gemParent == null) Debug.LogWarning("@Gems를 하이러키창에서 찾을 수 없습니다.");
    }
    private void Update()
    {
        #region 플레이어의 방향 계산
        // 플레이어와의 방향 벡터 계산 (y축 회전만 고려하려고 y=0 처리)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // 수직 방향은 무시하고 회전
        #endregion

        #region 플레이어에게 rotation
        // 몬스터가 플레이어를 바라보도록 회전
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );
        #endregion
        
        #region 플레이어와의 충돌 판단
        distance = Vector3.Distance(player.position,transform.position);
        if (distance <= stop_distance) isCollision = true;
        else if (distance > stop_distance) isCollision = false;
        #endregion

        #region 플레이어에게 전진 : 피격입은상태도 아니고 / 플레이어와 충돌 상태도 아니면
        //순조롭게 전진
        if (isKnockBack == false && isCollision == false) 
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //전진
        #endregion

        #region 넉백을 위해 플레이어에게 전진을 일시정지하고 넉백이 이루어질 시간 체크
        //전진하다가 데미지를 입어 넉백 타이머 시작 //위에 if문(플레이어에게 전진) 이 정지되어야 순수히 뒤로 넉백이 이루어질것임
        else if (isKnockBack == true){
            knockBackTimer += Time.deltaTime; //넉백 타이머
            transform.position = Vector3.MoveTowards(transform.position, transform.Find("KnockBackPosition").position, 3 * Time.deltaTime);
            if (knockBackTimer >= knockBackDuration) //넉백 지속시간 충족했으면
            {
                knockBackTimer = 0;
                isKnockBack = false; //넉백상태 아님으로 돌림
            }

        }
        #endregion

        #region 플레이어에게 데미지 입힘
        if(isCollision == true)
        {
            damage_Timer += Time.deltaTime;

            if (damage_Timer >= damage_delayTime)
            {
                damage_Timer = 0;
                Debug.Log(Managers.HP.OnDamaged(damage));
            }
            
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        #region projectile로 부터 데미지 입었을 때
        //Projectile 태그를 가진 오브젝트가 트리거에 들어왔을 때만 비활성화
        if (other.CompareTag("DamageSource"))
        {
            #region 체력감소, 넉백
            HP -= Managers.Damage.GetDamage((other.transform.parent != null) ? other.transform.parent.name : other.transform.name);
            isKnockBack = true;//넉백
            #endregion

            #region 사망처리 (비활성화, 잼드랍)
            if (HP <= 0)
            {
                //3. 0이면 비활성화 +체력을 MAXHP로 리셋
                GameObject instance_gem= Instantiate(gem, transform.position, Quaternion.identity, gemParent.transform);
                gameObject.SetActive(false);
                HP = MaxHP;
            }
            #endregion
        }
        #endregion
    }

}


