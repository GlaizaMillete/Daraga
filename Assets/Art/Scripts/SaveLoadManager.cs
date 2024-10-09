using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoadManager : MonoBehaviour
{
    public void SaveGame(GameData data)
    {
        PlayerPrefs.SetString("lastScene", data.lastSceneName);
        PlayerPrefs.SetFloat("playerPosX", data.playerPosition.x);
        PlayerPrefs.SetFloat("playerPosY", data.playerPosition.y);
        PlayerPrefs.SetFloat("playerPosZ", data.playerPosition.z);

        // Save unlocked chapters as a comma-separated string
        string unlockedChaptersString = string.Join(",", data.unlockedChapters);
        PlayerPrefs.SetString("unlockedChapters", unlockedChaptersString);

        PlayerPrefs.Save();
    }

    public GameData LoadGame()
    {
        if (PlayerPrefs.HasKey("lastScene"))
        {
            GameData data = new GameData();
            data.lastSceneName = PlayerPrefs.GetString("lastScene");
            data.playerPosition = new Vector3(
                PlayerPrefs.GetFloat("playerPosX"),
                PlayerPrefs.GetFloat("playerPosY"),
                PlayerPrefs.GetFloat("playerPosZ")
            );

            // Load the unlocked chapters
            string[] unlockedChaptersString = PlayerPrefs.GetString("unlockedChapters").Split(',');
            data.unlockedChapters = new bool[unlockedChaptersString.Length];
            for (int i = 0; i < unlockedChaptersString.Length; i++)
            {
                data.unlockedChapters[i] = unlockedChaptersString[i] == "True";
            }

            return data;
        }

        return null;
    }
}
