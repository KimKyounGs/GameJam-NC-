using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private const float TOTAL_TIME = 10 * 60; // 10분을 초로 변환
    private float remainingTime = TOTAL_TIME;

    [SerializeField] Text _Minutes; // 유니티 인스펙터에서 Text 오브젝트를 연결하세요.
    [SerializeField] Text _seconds;
    [SerializeField] Text _microseconds;

    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();

            if (Pear._pearCnt == 30)
            {
                Succes();
            }
        }
        else
        {
            _Minutes.text = 0.ToString();
            _seconds.text = 0.ToString();
            _microseconds.text = 0.ToString();
            if (Pear._pearCnt == 30)
            {
                Succes();
            }
            else
            {
                Failur();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = (int)(remainingTime / 60);
        int seconds = (int)(remainingTime % 60);
        int microseconds = (int)((remainingTime * 100) % 100);

        _Minutes.text = minutes.ToString();
        _seconds.text = seconds.ToString();
        _microseconds.text = microseconds.ToString();
    }

    void Succes()
    {
        Time.timeScale = 0f;
        GameClear.SetActive(true);
    }
    void Failur()
    {
        Time.timeScale = 0f;
        GameOver.SetActive(true);
    }
}
