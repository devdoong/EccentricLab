using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalSolid : MonoBehaviour
{
    public int howmany_Solid = 3;
    //SkillState에서 현재 스페셜스킬값(회전속도)를 가져오지만 초기값이 아직 Init()을 안해줘서 null이라 이때는 그냥 AbilityData에 있는 기본값을 가져와줌
    public Vector3 rotationSpeed = new Vector3(0, 0, 0);
    void Update()//
    {
        transform.position = Managers.Player.transform.position;
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        rotationSpeed = new Vector3(0, Managers.SkillState.specialState["RotationalSolid"], 0);
    }

    public void SpeedUp()
    {
        //SkillSelectButton에서 SkillState의 값을 변경(증가)해주고 호출해야 속도가 올라갈 것임.
        rotationSpeed = new Vector3(0, Managers.SkillState.specialState["RotationalSolid"], 0);
    }

    
}
