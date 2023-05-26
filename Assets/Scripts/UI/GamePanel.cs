using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI applesText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private float timeRemaining;
    private bool timeIsRunning = false;
    private void OnEnable()
    {
        //đăng kí sự kiện
        ItemCollector.collectAppleDelegate += OnPlayerCollectApples;
        SetTimeRemain(120);
        timeIsRunning = true;
    }
    private void Start()
    {
        applesText.text = GameManager.Instance.Aplles.ToString();
    }
    private void Update()
    {
        if(timeIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out");
                timeRemaining = 0;
                timeIsRunning = false;
                timeText.text = string.Format("{0:00}:{1:00}", 0, 0);
                if (AudioManager.HasInstance)
                {
                    AudioManager.Instance.PlaySE(AUDIO.SE_LOSE);
                }
                if(UIManager.HasInstance)
                {
                    Time.timeScale = 0f;
                    UIManager.Instance.ActiveLosePanel(true);
                }
            }
        }
    }
    private void OnDisable()
    {
        //hủy sự kiện
        ItemCollector.collectAppleDelegate -= OnPlayerCollectApples;
    }
    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void SetTimeRemain(float value)
    {
        timeRemaining = value;
    }
    private void OnPlayerCollectApples(int value)
    {
        applesText.text = value.ToString();
    }

}
