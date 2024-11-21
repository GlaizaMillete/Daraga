using UnityEngine;

public class JarPiece : MonoBehaviour
{
    public bool isCorrectlyPlaced = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("JarOutline"))
        {
            isCorrectlyPlaced = true;
            Debug.Log($"{gameObject.name} is correctly placed.");
        }
    }
}
