using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JarAssembleManager : MonoBehaviour
{
    public GameObject jarOutline; // Outline of the jar
    public GameObject[] jarPieces; // Array of jar pieces
    public Button finishButton; // Button to finish assembly

    private int piecesPlaced = 0;

    void Start()
    {
        InitializeJarPieces();
        finishButton.gameObject.SetActive(false);
    }

    // Initialize jar pieces
    private void InitializeJarPieces()
    {
        foreach (GameObject piece in jarPieces)
        {
            piece.SetActive(true);
            piece.GetComponent<DraggablePiece>().ResetPosition();
        }
    }

    // Called when a piece is correctly placed
    public void PiecePlaced()
    {
        piecesPlaced++;
        if (piecesPlaced == jarPieces.Length)
        {
            CompleteJarAssembly();
        }
    }

    // Called when jar assembly is complete
    private void CompleteJarAssembly()
    {
        Debug.Log("Jar assembly complete!");
        finishButton.gameObject.SetActive(true);
    }

    // Return to LiwaywayHouse scene after finishing
    public void GoBackToLiwaywayHouse()
    {
        // Save progress in PlayerPrefs
        PlayerPrefs.SetInt("JarAssemblyComplete", 1);

        // Load the LiwaywayHouse scene
        SceneManager.LoadScene("LiwaywayHouse");
    }
}
