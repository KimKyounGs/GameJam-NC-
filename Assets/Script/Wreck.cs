using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wreck : MonoBehaviour
{
    [SerializeField] GameObject Telescope;
    [SerializeField] Image TelescopeImage;
    [SerializeField] Sprite sprite;
    [SerializeField] GameObject announcementBox;
    [SerializeField] Text announcement;

    string text = "아무것도 없었습니다";
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
            GameBase._event = GetComponent<Event>();
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

    public void NoEvent()
    {
        NoUseTelesocpe();
        StartCoroutine(TypeContext());
    }

    IEnumerator TypeContext()
    {
        announcementBox.SetActive(true);
        float textDelay = 0.5f;
        for (int i = 0; i < text.Length; i++)
        {
            Debug.Log(i);
            string tLetter = text[i].ToString();
            announcement.text += tLetter;

            yield return new WaitForSeconds(textDelay);
        }
        announcementBox.SetActive(false);
        GameBase._bShipMove = true;
    } 
    
}
