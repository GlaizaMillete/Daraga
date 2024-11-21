
using UnityEngine;

public class JarOutline : MonoBehaviour
{
    private int piecesInside = 0;
    public int totalPieces = 0; // Set this to the total number of pieces
    public JarAssemble jarAssemble; // Reference to the JarAssemble script

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JarPiece"))
        {
            piecesInside++;
            Debug.Log($"Piece entered: {other.gameObject.name}. Total pieces inside: {piecesInside}");

            // Notify the JarAssemble script once all pieces are inside
            if (piecesInside == totalPieces && jarAssemble != null)
            {
                jarAssemble.TriggerReceiveBoxAnimation();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JarPiece"))
        {
            piecesInside--;
            Debug.Log($"Piece exited: {other.gameObject.name}. Total pieces inside: {piecesInside}");
        }
    }
}
