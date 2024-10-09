using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public GameObject ricoPrefab;
    public GameObject joystickPrefab;
    public GameObject cmCamPrefab;

    private GameObject currentRico;
    private GameObject currentJoystick;
    private GameObject currentCMCam;

    private Vector3 lastRicoPosition;
    private Vector3 lastCMCamPosition;

    // Define a list of quests with their corresponding scene names
    private Dictionary<string, string> quests = new Dictionary<string, string>
    {
        {"fishing", "fishing"}, // Add your quest name and scene here
        {"Sickle", "InsideCassavaFields"},
        {"Cassava", "InsideCassavaFields"}
    };

    private string currentQuest;

    // This method triggers when the player interacts with the NPC or quest object
    public void TriggerQuest(string questName)
    {
        if (quests.ContainsKey(questName))
        {
            currentQuest = questName;
            lastRicoPosition = currentRico.transform.position;
            lastCMCamPosition = currentCMCam.transform.position;

            // Destroy Rico, Joystick, and CMCam
            Destroy(currentRico);
            Destroy(currentJoystick);
            Destroy(currentCMCam);

            // Load the corresponding quest scene
            SceneManager.LoadScene(quests[questName]);
        }
        else
        {
            Debug.LogWarning("Quest not found: " + questName);
        }
    }

    // Call this method when the quest is completed to bring back Rico, Joystick, and CMCam
    public void CompleteQuest()
    {
        // Instantiate Rico, Joystick, and CMCam from prefabs
        currentRico = Instantiate(ricoPrefab, lastRicoPosition, Quaternion.identity);
        currentJoystick = Instantiate(joystickPrefab);
        currentCMCam = Instantiate(cmCamPrefab, lastCMCamPosition, Quaternion.identity);

        // Return to the main scene or any other scene after the quest ends
        SceneManager.LoadScene("MainScene"); // Change this to the scene you want to return to after the quest
    }

    // Ensure Rico, Joystick, and CMCam are set up on game start
    private void Start()
    {
        currentRico = Instantiate(ricoPrefab, lastRicoPosition, Quaternion.identity);
        currentJoystick = Instantiate(joystickPrefab);
        currentCMCam = Instantiate(cmCamPrefab, lastCMCamPosition, Quaternion.identity);
    }
}