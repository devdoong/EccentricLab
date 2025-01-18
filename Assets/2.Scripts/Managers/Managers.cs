                                                                                                                                                using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static bool s_initialized = false;

    public GameObject HealPack_btn;
    public GameObject[] list_SkillSelect_btn;


    public static GameObject closeEnemy;
    public Sprite[] sprites;

    GameObject levelUp_UI;


    #region Managers
    PoolManager _pool = new PoolManager();
    public static PoolManager Pool { get { return Instance?._pool; } }
    LevelManager _level = new LevelManager();
    public static LevelManager Level { get { return Instance?._level; } }
    HPManager _hp = new HPManager();
    public static HPManager HP { get { return Instance?._hp; } }
    DamageManager _damage = new DamageManager();
    public static DamageManager Damage { get { return Instance?._damage; } }
    SkillStateManager _skillState = new SkillStateManager();
    public static SkillStateManager SkillState { get { return Instance?._skillState; } }
    #endregion
    #region Controller
    PlayerController _playerController = new PlayerController();
    public static PlayerController PlayerController { get { return Instance?._playerController; } }
    ProjectileController _projectile = new ProjectileController();
    public static ProjectileController Projectile { get { return Instance?._projectile; } }
    #endregion
    #region Contents
    RandomSkill _randomSkill = new RandomSkill();
    public static RandomSkill RandomSkill { get { return Instance?._randomSkill; } }
    #endregion
    #region Datas
    AbilityDatas _abilityDatas = new AbilityDatas();
    public static AbilityDatas AbilityDatas { get { return Instance?._abilityDatas; } }
    #endregion
    #region 임시
    public Transform player;
    public GameObject enemy;
    public static Transform Player { get { return Instance?.player; } }
    public static GameObject Enemy { get { return Instance?.enemy; } }
    #endregion
    #region Managers 시작 작업
    private void Awake()
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_instance = this;
        DontDestroyOnLoad(gameObject);

        _abilityDatas.Init();
        _skillState.Init();
        _pool.Init();
        _damage.Init();
/*
        foreach (var data in SkillState.abilityLevelState.Keys.ToList())
        {
            SkillState.abilityLevelState[data] = 4;
        }*/

        levelUp_UI = Managers.Instance.Find_GO("LevelUp");
        LevelManager.LevelUP_CB += LevelUP_UIManager;

    }


    public static Managers Instance
    {
        get
        {
            return s_instance;
        }
    }


    #endregion


    #region 레벨업 관련 매니저
    string[] selected = new string[3];
    private void LevelUP_UIManager()
    {
        Managers.RandomSkill.Reset(); // 이전 선택된 스킬 초기화
        int count = 0;

        for (int i = 0; i < list_SkillSelect_btn.Length; i++)
        {
            string random_skill_name = Managers.RandomSkill.GetRandomKey();
            Debug.Log(random_skill_name);
            selected[i] = random_skill_name;

            if (random_skill_name != null)
            {
                list_SkillSelect_btn[i].SetActive(true);

                UnityEngine.UI.Image[] get_imageComponent = list_SkillSelect_btn[i].GetComponentsInChildren<UnityEngine.UI.Image>();
                UnityEngine.UI.Image image_level = get_imageComponent[1];

                Text[] get_textComponent = list_SkillSelect_btn[i].GetComponentsInChildren<Text>();
                Text text_level = get_textComponent[0];

                text_level.text = "Level : " + Managers.SkillState.abilityLevelState[random_skill_name].ToString();
                image_level.sprite = Managers.AbilityDatas.dic_skillData[random_skill_name].icon_sprite;
            }
            else
            {
                Debug.Log(list_SkillSelect_btn[i] + "는 가져갈게 없어서 활성화 불가");
                count++;
            }

            if (count == 3)
            {
                Debug.Log("만랩처리");
                HealPack_btn.SetActive(true);
            }
        }
    }

    public string Skill_Selected(string name)
    {

        #region skill state에서 int를 밸류로 가진 level state 의 레벨을 ++
        if (int.TryParse(name, out int index)) // 클릭한 버튼 이름을 int로 변환 시도
        {
            SkillState.abilityLevelState[selected[index]]++;
        }
        else
        {
            Debug.LogError($"'{name}'은 정수로 변환할 수 없습니다.");
        }
        #endregion



        for (int i = 0; i < list_SkillSelect_btn.Length; i++)
        {
            list_SkillSelect_btn[i].SetActive(false);
        }
        GameObject levelUp = Managers.Instance.Find_GO("LevelUp");
        levelUp.SetActive(false);
        Time.timeScale = 1f;

        return selected[index];

    }
    #endregion

    public void Update()
    {
        closeEnemy = GetCloseEnemy();
    }

    #region 유틸함수
    public GameObject Find_GO(string obj_name)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.name.Equals(obj_name, System.StringComparison.OrdinalIgnoreCase))
            {
                return obj;
            }
        }
        Debug.Log("Find_InactiveObject: 찾을 수 없음");
        return null;
    }
    public GameObject InstantiatePrefab(GameObject prefab, Transform transform)
    {
        return Instantiate(prefab, transform);
    }

    #endregion

    #region 타겟 Enemy 서칭
    public GameObject GetCloseEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy"); //Enemy 태그 전체 검사

        if (enemys.Length == 0) return null;

        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemys)
        {
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
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