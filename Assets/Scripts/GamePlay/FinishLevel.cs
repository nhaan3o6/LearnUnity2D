using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("CompleteLevel", 1f);
        }
    }
    private void CompleteLevel()
    {
        if(SceneManager.GetActiveScene().name.Equals("Level2"))
        {
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_VICTORY);
            }
            //hiện UI chiến thắng
            if(UIManager.HasInstance)
            {
                Time.timeScale = 0f;
                UIManager.Instance.ActiveVictoryPanel(true);
            }
        }
        else
        {
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_FINISH);
                AudioManager.Instance.PlayBGM(AUDIO.BGM_BGM_04);
            }
            SceneManager.LoadScene("Level2");
        }
    }
}
