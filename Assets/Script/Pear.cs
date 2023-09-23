using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pear : MonoBehaviour
{
    public static Pear instance;
    public static int _pearCnt = 0;

    [SerializeField] Text pearText;
    void Start()
    {
        instance = this;
    }

    public void BeLifesaving()
    {
        _pearCnt += 5;
        UpdatePearCnt();
    }
    
    public void GetPear()
    {
        _pearCnt ++;
        UpdatePearCnt();
    }

    void UpdatePearCnt()
    {
        pearText.text = ": " + _pearCnt.ToString() + "/30";
    }
}
