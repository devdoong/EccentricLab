using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectButton : MonoBehaviour
{



    //��ư�� �������� ������ 3���� ��ȯ�� �� Ŭ���� �ϳ� �ʿ�.
    //�� Ŭ���������� ��ų�̸��� ��ȯ���ְ� �������� SkillStateManager ���� ����
    //

    public Image _image;
    public Text _text;
    public List<Sprite> sprites;
    public Dictionary<string,Sprite> dic_sprites;

    void Start()
    {
        _image = GetComponent<Image>();
        _text = GetComponent<Text>();
    }

    void test()
    {
        _image.sprite = sprites[0];
    }
}
