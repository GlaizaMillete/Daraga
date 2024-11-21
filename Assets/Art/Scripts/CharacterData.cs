using UnityEngine;

[System.Serializable]
public class CharacterData : MonoBehaviour
{
    public string Name;
    public Sprite Icon;
    public string[] DialogueBeforeRiddle;
    public string RiddleQuestion;
    public string[] Options; // Options A, B, C
    public int CorrectAnswerIndex; // 0 for A, 1 for B, 2 for C
    public string CorrectDialogue;
    public string IncorrectDialogue;
    public Dialogue DialogueAfterRiddle; // Dialogue after the riddle
}
