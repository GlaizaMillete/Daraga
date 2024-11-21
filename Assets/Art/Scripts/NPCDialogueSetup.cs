using UnityEngine;

public class RiddleDialogueManager : MonoBehaviour
{
    public RiddleDialogue riddleDialogue;

    public Sprite neroIcon, bagwisIcon, marinaIcon, marisaIcon, dalisayIcon;

    private void Start()
    {
        riddleDialogue.npcData = new CharacterData[]
        {
            new CharacterData
            {
                Name = "Nero",
                Icon = neroIcon,
                DialogueBeforeRiddle = new string[] { "Hello! I have a riddle for you." },
                RiddleQuestion = "What has keys but can't open locks?",
                Options = new string[] { "A) A piano", "B) A map", "C) A lockpick" },
                CorrectAnswerIndex = 0,
                CorrectDialogue = "Correct! A piano has keys, but it can't open locks.",
                IncorrectDialogue = "Oops! Try again.",
                DialogueAfterRiddle = new Dialogue() { dialogueLines = new DialogueLine[] { new DialogueLine { line = "Well done, you solved the riddle!" } } }
            },
            new CharacterData
            {
                Name = "Bagwis",
                Icon = bagwisIcon,
                DialogueBeforeRiddle = new string[] { "Greetings! Let me test your wit." },
                RiddleQuestion = "I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?",
                Options = new string[] { "A) A shadow", "B) An echo", "C) A dream" },
                CorrectAnswerIndex = 1,
                CorrectDialogue = "Correct! An echo is the answer.",
                IncorrectDialogue = "Incorrect! Think about it again.",
                DialogueAfterRiddle = new Dialogue() { dialogueLines = new DialogueLine[] { new DialogueLine { line = "Well played, my friend." } } }
            },
            new CharacterData
            {
                Name = "Marina",
                Icon = marinaIcon,
                DialogueBeforeRiddle = new string[] { "Are you ready for a challenge?" },
                RiddleQuestion = "What can travel around the world while staying in the corner?",
                Options = new string[] { "A) A stamp", "B) A cloud", "C) A clock" },
                CorrectAnswerIndex = 0,
                CorrectDialogue = "That's right! A stamp stays in the corner of an envelope.",
                IncorrectDialogue = "Not quite, but keep trying.",
                DialogueAfterRiddle = new Dialogue() { dialogueLines = new DialogueLine[] { new DialogueLine { line = "Good job, you cracked it!" } } }
            },
            new CharacterData
            {
                Name = "Marisa",
                Icon = marisaIcon,
                DialogueBeforeRiddle = new string[] { "Here’s a tricky one for you!" },
                RiddleQuestion = "What has many teeth but can't bite?",
                Options = new string[] { "A) A comb", "B) A zipper", "C) A saw" },
                CorrectAnswerIndex = 0,
                CorrectDialogue = "Correct! A comb has many teeth but can't bite.",
                IncorrectDialogue = "Try again! Think of something that has 'teeth' but no bite.",
                DialogueAfterRiddle = new Dialogue() { dialogueLines = new DialogueLine[] { new DialogueLine { line = "Well done, you solved it!" } } }
            },
            new CharacterData
            {
                Name = "Dalisay",
                Icon = dalisayIcon,
                DialogueBeforeRiddle = new string[] { "Let me give you a puzzle to solve." },
                RiddleQuestion = "What can be cracked, made, told, and played?",
                Options = new string[] { "A) A joke", "B) A puzzle", "C) A story" },
                CorrectAnswerIndex = 0,
                CorrectDialogue = "You got it! A joke can be cracked, made, told, and played.",
                IncorrectDialogue = "Wrong! Try again.",
                DialogueAfterRiddle = new Dialogue() { dialogueLines = new DialogueLine[] { new DialogueLine { line = "Nice work, you figured it out!" } } }
            }
        };
    }
}
