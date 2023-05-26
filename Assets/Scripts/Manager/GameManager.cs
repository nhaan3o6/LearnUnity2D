using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
    private const string AppleKey = "Apple";
    private int apples = 0;
    public int Aplles => apples;

    private bool isPlaying = false;
    public bool IsPlaying => isPlaying;
    protected override void Awake()
    {
        base.Awake();
        apples = PlayerPrefs.GetInt(AppleKey, 0);
    }

    public void UpdateAplle(int value)
    {
        apples = value;
    }
    public void StartGame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        if(isPlaying)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }
    }
    public void ResumeGame()
    {
        if(!isPlaying)
        {
            isPlaying = true;
            Time.timeScale = 1f;
        }
    }
    public void ReStartGame()
    {
        ChangeScene("Menu");
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ActiveMenuPanel(true);
            UIManager.Instance.ActiveGamePanel(false);
            UIManager.Instance.ActiveVictoryPanel(false);
            UIManager.Instance.ActiveLosePanel(false);
        }
    }
    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(AppleKey, apples);
    }
}
