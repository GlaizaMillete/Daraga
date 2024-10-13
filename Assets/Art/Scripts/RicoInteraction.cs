using UnityEngine;

public class RicoInteraction : MonoBehaviour
{
    public Sprite newRicoSprite; // New sprite after getting the clothes
    private SpriteRenderer ricoSpriteRenderer; // Rico's SpriteRenderer
    private bool hasClothes = false; // To track if Rico got the clothes
    private bool isInsideHouse = false; // To track if Rico is inside the house

    void Start()
    {
        // Get the SpriteRenderer component attached to Rico
        ricoSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Trigger when Rico enters Liwayway's house
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Liwayway")) // Check if Rico interacts with Liwayway
        {
            TalkToLiwayway();
        }

        if (other.CompareTag("Door") && hasClothes && isInsideHouse) // Check if Rico leaves the house after getting clothes
        {
            ExitHouse();
        }
    }

    // Trigger when Rico leaves Liwayway's house
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("House"))
        {
            isInsideHouse = false; // Rico has left the house
        }
    }

    // Interaction with Liwayway
    void TalkToLiwayway()
    {
        // Simulate the dialogue with Liwayway
        Debug.Log("Liwayway: 'Get some clothes here.'");

        // Rico gets the clothes
        hasClothes = true;
        isInsideHouse = true;
    }

    // Change Rico's sprite after leaving the house
    void ExitHouse()
    {
        Debug.Log("Rico leaves the house with new clothes.");
        ricoSpriteRenderer.sprite = newRicoSprite; // Change to the new sprite
    }
}
