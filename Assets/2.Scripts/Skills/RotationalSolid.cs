using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalSolid : MonoBehaviour
{
    public int howmany_Solid = 3;
    //SkillState���� ���� ����Ƚ�ų��(ȸ���ӵ�)�� ���������� �ʱⰪ�� ���� Init()�� �����༭ null�̶� �̶��� �׳� AbilityData�� �ִ� �⺻���� ��������
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
        //SkillSelectButton���� SkillState�� ���� ����(����)���ְ� ȣ���ؾ� �ӵ��� �ö� ����.
        rotationSpeed = new Vector3(0, Managers.SkillState.specialState["RotationalSolid"], 0);
    }

    
}
