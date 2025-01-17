                                                                                                                                                using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance;
    static bool s_initialized = false;
    public GameObject HealPack;
    public GameObject[] list_LevelUp;

    public static GameObject closeEnemy;
    public Sprite[] sprites;

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
    public static RandomSkill RandomSkill { get {  return Instance?._randomSkill; } }
    #endregion

    #region Datas
    AbilityDatas _abilityDatas = new AbilityDatas();
    public static AbilityDatas AbilityDatas{ get { return Instance?._abilityDatas; } }      
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
        _randomSkill.Init();

        foreach (var data in SkillState.abilityLevelState.Keys.ToList())
        {
            SkillState.abilityLevelState[data] = 4;
        }
        
    }
    public static Managers Instance
    {
        get
        {
            return s_instance;
        }
    }


    #endregion

   




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


    public GameObject InstantiatePrefab(GameObject prefab,Transform transform)
    {
        return Instantiate(prefab, transform);
    }

    public void Update()
    {
        closeEnemy = GetCloseEnemy();
    }

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
