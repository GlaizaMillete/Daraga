using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JarAssembleScript : MonoBehaviour
{
    public GameObject topTable;
    public GameObject[] jarPieces;
    public GameObject jarOutline;
    public Button receiveBoxButton;

    private bool isJarAssembled = false;

    private void Start()
    {
        receiveBoxButton.gameObject.SetActive(false);
        receiveBoxButton.onClick.AddListener(OnReceiveBoxClicked);
    }

    public void Update()
    {
        // Check if all jar pieces are in place
        if (!isJarAssembled && AreAllPiecesInPlace())
        {
            isJarAssembled = true;
            receiveBoxButton.gameObject.SetActive(true);
        }
    }

    bool AreAllPiecesInPlace()
    {
        foreach (GameObject piece in jarPieces)
        {
            if (Vector3.Distance(piece.transform.position, jarOutline.transform.position) > 0.5f)
            {
                return false;
            }
        }
        return true;
    }

    public void OnReceiveBoxClicked()
    {
        // Notify LiwaywayHouseScript that the jar assembly is successful
        LiwaywayHouseScript liwaywayHouseScript = FindObjectOfType<LiwaywayHouseScript>();
        if (liwaywayHouseScript != null)
        {
            liwaywayHouseScript.OnJarAssembleSuccess();
        }
    }
}