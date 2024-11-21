using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionManager : MonoBehaviour
{
    public Button characterSelectionButton;
    public GameObject characterSelectionContent;
    public Toggle showOnlyCharacterSelectionToggle;
    public Animator[] characterAnimators;
    public Button arrowLeft;
    public Button arrowRight;
    public Button selectButton;

    private void Start()
    {
        characterSelectionButton.interactable = false;
        characterSelectionContent.SetActive(false);
       

        // Initialize character animators
        foreach (var animator in characterAnimators)
        {
            if (animator == null)
            {
                Debug.LogError("Animator reference is missing!");
            }
            else
            {
                animator.Play("Idle");
            }
        }

        // Initialize arrow buttons
        if (arrowLeft != null && arrowRight != null)
        {
            arrowLeft.onClick.AddListener(PreviousCharacter);
            arrowRight.onClick.AddListener(NextCharacter);
        }
    }

    public void ShowCharacterSelection()
    {
        characterSelectionButton.interactable = true;
        characterSelectionContent.SetActive(true);
        showOnlyCharacterSelectionToggle.isOn = true;

        // Play animation to reveal character selection content
        if (characterAnimators.Length > 0)
        {
            foreach (var animator in characterAnimators)
            {
                if (animator != null)
                {
                    animator.Play("Reveal");
                }
            }
        }
    }

    public void HideCharacterSelection()
    {
        characterSelectionButton.interactable = false;
        characterSelectionContent.SetActive(false);
        showOnlyCharacterSelectionToggle.isOn = false;

        // Play animation to hide character selection content
        if (characterAnimators.Length > 0)
        {
            foreach (var animator in characterAnimators)
            {
                if (animator != null)
                {
                    animator.Play("Hide");
                }
            }
        }
    }

    public void ChangeCharacter(int index)
    {
        if (index >= 0 && index < characterAnimators.Length)
        {
            foreach (var animator in characterAnimators)
            {
                if (animator != null)
                {
                    animator.Play(index.ToString());
                }
            }
        }
    }

    public void SelectCharacter()
    {
        // Apply selected character to player
        // This should be implemented in CharacterMovement script
        Debug.Log("Selected character: " + showOnlyCharacterSelectionToggle.isOn);
    }

    private void PreviousCharacter()
    {
        int currentIndex = Array.FindIndex(characterAnimators, anim => anim.GetCurrentAnimatorStateInfo(0).IsName(showOnlyCharacterSelectionToggle.isOn.ToString()));
        int newIndex = Mathf.Max(0, --currentIndex);
        ChangeCharacter(newIndex);
    }

    private void NextCharacter()
    {
        int currentIndex = Array.FindIndex(characterAnimators, anim => anim.GetCurrentAnimatorStateInfo(0).IsName(showOnlyCharacterSelectionToggle.isOn.ToString()));
        int newIndex = Mathf.Min(characterAnimators.Length - 1, ++currentIndex);
        ChangeCharacter(newIndex);
    }
}