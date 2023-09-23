using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class People
{
    [Tooltip("사람 이름")]
    public string _name;

    [Tooltip("스프라이트")]
    public Sprite _sprite;

    [Tooltip("대화 ID")]
    public int _ID;

    [Tooltip("대화")]
    public Dialogue _diaglue; 
}
