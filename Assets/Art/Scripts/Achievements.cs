using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchievement", menuName = "Achievements/Achievement")]
public class Achievements : MonoBehaviour
{
   public string questName; // Name of the quest
    public string description; // Quest description
    public bool isCompleted; // Status of the quest
}
