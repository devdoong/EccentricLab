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

    //넉백 애니메이션
    public Animator animator; // Animator 연결
    public string animationName = "3-great_damage_torso_front";
    public AnimatorStateInfo anim_stateInfo;
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

    #region 오디오 소스
    private AudioSource[] audioSources;
    #endregion

    private void Awake()
    {
        audioSources = GetComponents<AudioSource>();
    }
    private void Start()
    {
        player = GameObject.Find("BasicArcher").transform;
        gemParent = GameObject.Find("@Gems");
        if (gemParent == null) Debug.LogWarning("@Gems를 하이러키창에서 찾을 수 없습니다.");

        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator가 연결되지 않았습니다.");
        }
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
            turnSpeed * Time.deltaTime);
        #endregion

        #region 플레이어와의 충돌 판단
        distance = Vector3.Distance(player.position, transform.position);
        if (distance <= stop_distance) isCollision = true;
        else if (distance > stop_distance) isCollision = false;
        #endregion

        #region 전진/넉백
        anim_stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (IsAnimationPlaying(animationName) == false && isCollision == false)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //전진
        }
        else if (IsAnimationPlaying(animationName) == true)
        {
            transform.Translate(Vector3.back * moveSpeed/2 * Time.deltaTime);
        }
        #endregion

        #region 플레이어에게 데미지 입힘
        if(isCollision == true)
        {
            damage_Timer += Time.deltaTime;

            if (damage_Timer >= damage_delayTime)
            {
                damage_Timer = 0;
                Managers.HP.OnDamaged(damage);
            }
            
        }
        #endregion
    }
    bool IsAnimationPlaying(string name)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // 0은 기본 레이어 인덱스
        return stateInfo.IsName(name);
    }

    private void OnTriggerEnter(Collider other)
    {
        #region 데미지 입었을 때
        //데미지소스 태그를 가진 오브젝트가 트리거에 들어왔을 때만 비활성화
        if (other.CompareTag("DamageSource"))
        {
            #region 체력감소
            HP -= Managers.SkillState.GetState((other.transform.parent != null) ? other.transform.parent.name : other.transform.name);
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

            #region 넉백 애니메이션
            animator.SetTrigger("isHit");
            #endregion


            audioSources[0].Play();

            if (other.gameObject.name.Contains("Arrow"))
            {
                audioSources[1].Play();
            }

        }
        #endregion
    }

}


