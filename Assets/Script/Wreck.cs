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
    [SerializeField] Text targetText;
    [SerializeField] private float fadeDuration = 2.0f; // 2초 동안 투명도 조절
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
        StartCoroutine(FadeTextCoroutine());
    }

    IEnumerator FadeTextCoroutine()
    {
        // 나타나게 하기
        yield return Fade(0, 1);

        // 잠시 대기
        yield return new WaitForSeconds(1.0f);

        // 사라지게 하기
        yield return Fade(1, 0);
    }

    IEnumerator Fade(float startAlpha, float endAlpha)
    {
        Color startColor = new Color(targetText.color.r, targetText.color.g, targetText.color.b, startAlpha);
        Color endColor = new Color(targetText.color.r, targetText.color.g, targetText.color.b, endAlpha);

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;

            targetText.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        targetText.color = endColor;
    }
    
}
