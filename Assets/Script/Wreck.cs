using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wreck : MonoBehaviour
{
    [SerializeField] GameObject Telescope;
    [SerializeField] Image TelescopeImage;
    [SerializeField] Sprite sprite;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameBase._isWreckColliderOn = true;
        GameBase._wreck = this;
        
        if (GetComponent<Event>() != null)
        {
            //GetComponent<Event>().StartEvent();
            //Debug.Log("YesEvent");
        }
        else
        {
            //Debug.Log("NoEvent");
        }
    }   

    void OnCollisionExit2D(Collision2D other)
    {
        GameBase._isWreckColliderOn = false;
        GameBase._wreck = null;
    }

    public void UseTelescope()
    {
        TelescopeImage.sprite = sprite;
        SettingUI(true);
    }

    public void NoUseTelesocpe()
    {
        TelescopeImage.sprite = null;
        SettingUI(false);
    }

    void SettingUI(bool pFlag)
    {
        Telescope.SetActive(pFlag);
    }
}
