using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCompletion : MonoBehaviour
{
    public QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    public void CompleteFishingQuest()
    {
        if (questManager != null)
        {
            questManager.CompleteQuest();
        }
    }
}
