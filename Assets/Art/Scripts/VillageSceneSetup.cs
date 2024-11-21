using UnityEngine;
using UnityEngine.SceneManagement;

public class VillageSceneSetup : MonoBehaviour
{
    public Sprite oldSprite;  // Assign the old sprite in the inspector
    public Sprite newSprite;  // Assign the new sprite in the inspector
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        // Read the flag from PlayerPrefs
        int useNewSprite = PlayerPrefs.GetInt("UseNewSprite", 0);
        Debug.Log("UseNewSprite value: " + useNewSprite);

        // Switch sprite based on the flag
        if (useNewSprite == 1)
        {
            SwitchToNewSprite();
            // Reset the flag if you want to only use it once
            PlayerPrefs.SetInt("UseNewSprite", 0);
        }
        else
        {
            SwitchToOldSprite();
        }
    }

    public void SwitchToNewSprite()
    {
        spriteRenderer.sprite = newSprite;
        animator.SetBool("isNewSprite", true);
        Debug.Log("Switched to new sprite.");
    }

    public void SwitchToOldSprite()
    {
        spriteRenderer.sprite = oldSprite;
        animator.SetBool("isNewSprite", false);
        Debug.Log("Switched to old sprite.");
    }
}
