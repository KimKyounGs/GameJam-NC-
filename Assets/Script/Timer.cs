using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private const float TOTAL_TIME = 10 * 60; // 10���� �ʷ� ��ȯ
    private float remainingTime = TOTAL_TIME;

    [SerializeField] Text _Minutes; // ����Ƽ �ν����Ϳ��� Text ������Ʈ�� �����ϼ���.
    [SerializeField] Text _seconds;
    [SerializeField] Text _microseconds;
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            _Minutes.text = 0.ToString();
            _seconds.text = 0.ToString();
            _microseconds.text = 0.ToString();
        }
    }

    void UpdateTimerText()
    {
        int minutes = (int)(remainingTime / 60);
        int seconds = (int)(remainingTime % 60);
        int microseconds = (int)((remainingTime * 10) % 10);

        _Minutes.text = minutes.ToString();
        _seconds.text = seconds.ToString();
        _microseconds.text = microseconds.ToString();
    }
}
