using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public string lastSceneName;          // Name of the last saved scene
    public Vector3 playerPosition;        // Position of the player when last saved
    public bool[] unlockedChapters;       // Array to track unlocked chapters
}
