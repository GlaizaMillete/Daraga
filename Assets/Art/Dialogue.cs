using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public DialogueLine[] dialogueLines; // Array of dialogue lines
}

[System.Serializable]
public class DialogueLine
{
    public Character character; // Reference to a character
    public string line; // The dialogue text
}

[System.Serializable]
public class Character
{
    public string name; // Character name
    public Sprite icon; // Character icon
}
