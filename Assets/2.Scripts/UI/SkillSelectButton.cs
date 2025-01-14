using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelectButton : MonoBehaviour
{



    //버튼을 눌렀을때 랜덤한 3개를 반환해 줄 클래스 하나 필요.
    //위 클래스에서는 스킬이름만 반환해주고 나머지는 SkillStateManager 에서 관리
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
