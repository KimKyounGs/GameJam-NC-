using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    [Tooltip("ID")]
    public int _ID;

    [Tooltip("이름")]
    public string _characterName;

    [Tooltip("대화")]
    public string[] _contexts;

    [Tooltip("폰트 크기")]
    public int _fontSize;

    [Tooltip("폰트 색깔")]
    public int _fontColor;

    [Tooltip("스프라이트")]
    public string _sprite;

    [Tooltip("브금")]
    public string _music;
}
