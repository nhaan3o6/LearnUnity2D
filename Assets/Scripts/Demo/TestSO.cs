using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TestSO : MonoBehaviour
{
    public TextMeshProUGUI PlayerMaxHealth;
    public TextMeshProUGUI PlayerMoveSpeed;
    public TextMeshProUGUI EnemyDamage;
    void Start()
    {
        if(DataManager.Instance!=null)
        {
            DataManager.Instance.Init();
            LoadData();
        }
    }
    private void LoadData()
    {
        var globalConfig = DataManager.Instance.GlobalConfig;
        PlayerMaxHealth.text = "PlayerMaxHealth: " + globalConfig.globalConfig.PlayerMaxHealth;
        PlayerMoveSpeed.text = "PlayerMoveSpeed: " + globalConfig.globalConfig.PlayerMoveSpeed;
        EnemyDamage.text = "EnemyDamage: " + globalConfig.globalConfig.EnemyDamage;

    }
    public void UpdateConfigData(int amout)
    {
        var globalConfig = DataManager.Instance.GlobalConfig;
        globalConfig.globalConfig.PlayerMaxHealth += amout;
        globalConfig.globalConfig.PlayerMoveSpeed += amout;
        globalConfig.globalConfig.EnemyDamage += amout;
        DataManager.Instance.SaveData();
        LoadData();

    }

}
