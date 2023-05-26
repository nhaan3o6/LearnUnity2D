using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class JSONdemo : MonoBehaviour
{
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI playerLevel;
    public TextMeshProUGUI playerGold;
    public ListPlayer listPlayer;
    private string json;
    private string dataPath;

    private void Awake()
    {
        dataPath = Application.dataPath + "/PlayerData.json";
        Debug.Log(dataPath);
    }
    // Start is called before the first frame update
    void Start()
    {
        //DataPlayer playerData = new DataPlayer
        //{
        //    Name = "Cat",
        //    Level = 1,
        //    Gold = 200
        //};
        //json = JsonUtility.ToJson(playerData);
        json = JsonUtility.ToJson(listPlayer);
        Debug.Log(json);
    }
    public void LoadPlayerData()
    {
        string loadJSON = File.ReadAllText(dataPath);
        if (loadJSON != null)
        {
            //DataPlayer loadedPlayerData = JsonUtility.FromJson<DataPlayer>(loadJSON);
            //playerName.text = "Player Name: " + loadedPlayerData.Name;
            //playerLevel.text = "Player Level: " + loadedPlayerData.Level;
            //playerGold.text = "Player Gold: " + loadedPlayerData.Gold;

            ListPlayer loadedPlayerData = JsonUtility.FromJson<ListPlayer>(loadJSON);
            playerName.text = "Player Name: " + loadedPlayerData.playerData[2].Name;
            playerLevel.text = "Player Level: " + loadedPlayerData.playerData[2].Level;
            playerGold.text = "Player Gold: " + loadedPlayerData.playerData[2].Gold;
        }
    }
    public void SavePlayerData()
    {
        File.WriteAllText(dataPath, json);
    }
    // Update is called once per frame
    public void UpdatePlayerData()
    {
        DataPlayer newData = new DataPlayer
        {
            Name = "Dog",
            Level = 2,
            Gold = 1000
        };
        playerName.text = "Player Name: " + newData.Name;
        playerLevel.text = "Player Level: " + newData.Level;
        playerGold.text = "Player Gold: " + newData.Gold;
        json = JsonUtility.ToJson(newData);
        SavePlayerData();
    }
}
