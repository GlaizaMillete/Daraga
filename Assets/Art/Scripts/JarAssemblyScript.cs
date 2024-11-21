using UnityEngine;

public class JarAssemblyScript : MonoBehaviour
{
    public Transform[] snapPoints;  // The positions where pieces need to be placed
    public GameObject[] jarPieces;  // The individual pieces of the jar
    public GameObject jarOutline;  // The outline where the jar will be assembled

    private bool[] isPlaced;  // To track which pieces are placed correctly
    private SpriteRenderer[] pieceRenderers;  // To store SpriteRenderers of jar pieces for sorting

    public bool isAssembled = false;  // New public property to track if the jar is assembled
    public ArrowTableScript arrowTableScript;  // Reference to ArrowTableScript

    void Start()
    {
        isPlaced = new bool[jarPieces.Length];
        pieceRenderers = new SpriteRenderer[jarPieces.Length];

        // Get all SpriteRenderers for jarPieces
        for (int i = 0; i < jarPieces.Length; i++)
        {
            pieceRenderers[i] = jarPieces[i].GetComponent<SpriteRenderer>();
        }

        if (arrowTableScript == null)
        {
            Debug.LogError("ArrowTableScript reference is not assigned in the inspector!");
        }
    }

    public void OnPiecePlaced(int pieceIndex)
    {
        if (Vector2.Distance(jarPieces[pieceIndex].transform.position, snapPoints[pieceIndex].position) < 1.0f)
        {
            jarPieces[pieceIndex].transform.position = snapPoints[pieceIndex].position;
            isPlaced[pieceIndex] = true;
            CheckAssemblyCompletion();
        }
    }

    private void CheckAssemblyCompletion()
    {
        // Check if all pieces are placed correctly
        foreach (bool placed in isPlaced)
        {
            if (!placed)
            {
                return;  // If any piece is not placed, return
            }
        }

        // All pieces are placed correctly, notify success
        Debug.Log("Jar assembled!");
        isAssembled = true;  // Set the assembly status to true
        arrowTableScript.CompleteJarAssembly();  // Notify the main script about completion
    }

    // Call this method when starting to drag a piece to ensure it's on top
    public void OnPieceStartDrag(int pieceIndex)
    {
        pieceRenderers[pieceIndex].sortingLayerName = "AboveUI";  // Make sure "AboveUI" exists in your sorting layers
        pieceRenderers[pieceIndex].sortingOrder = 10;  // Ensure it's above the UI layers during drag
    }

    // Call this method when drag ends or piece is placed correctly
    public void OnPieceStopDrag(int pieceIndex)
    {
        pieceRenderers[pieceIndex].sortingLayerName = "Default";  // Reset to the default layer
        pieceRenderers[pieceIndex].sortingOrder = 0;  // Reset sorting order to default
    }

    public void OnJarAssemblyComplete()
    {
        // Call CompleteJarAssembly when the player successfully assembles the jar
        if (arrowTableScript != null)
        {
            arrowTableScript.CompleteJarAssembly();
        }
    }
}
 