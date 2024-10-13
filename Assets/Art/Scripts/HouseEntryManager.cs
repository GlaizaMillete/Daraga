using UnityEngine;

public class HouseEntryManager : MonoBehaviour
{
    public GameObject rico; // Rico's character
    public GameObject door; // The door GameObject
    public Vector3 insidePosition; // Position where Rico should appear inside the house

    private bool isInside = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if Rico has collided with the door
        if (collision.gameObject == rico && !isInside)
        {
            // Set Rico to be inside the house and move him to the defined position
            rico.transform.position = insidePosition;
            isInside = true;

            // Disable the door to prevent overlap
            door.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If Rico exits the house, re-enable the door
        if (collision.gameObject == rico && isInside)
        {
            door.SetActive(true);
            isInside = false;
        }
    }
}
