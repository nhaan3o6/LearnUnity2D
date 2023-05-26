using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPanel : MonoBehaviour
{
    public void OnClickedRestartButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.ReStartGame();
        }
    }
    public void OnClickedExitButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.EndGame();
        }
    }
}
