using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExitLiwaywayHouse : MonoBehaviour
{
    public GameObject arrowExitDoorButton;
    public GameObject newPlayerSprite;

    private GameObject currentPlayer;
    private bool inLiwaywayHouse = true;

    void Start()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        arrowExitDoorButton.SetActive(inLiwaywayHouse);
    }

    void Update()
    {
        if (inLiwaywayHouse && Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (arrowExitDoorButton.GetComponent<Collider2D>().bounds.Contains(mousePosition))
            {
                ExitLiwaywayHouse();
            }
        }
    }

    void ExitLiwaywayHouse()
    {
        SceneManager.sceneLoaded += OnVillageSceneLoaded;
        SceneManager.LoadScene("VillageScene");
        inLiwaywayHouse = false;

        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
        }
    }

    void OnVillageSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "VillageScene")
        {
            SceneManager.sceneLoaded -= OnVillageSceneLoaded;

            Transform villageReturnPosition = GameObject.Find("VillageReturnPosition")?.transform;
            if (villageReturnPosition != null)
            {
                GameObject newPlayerInstance = Instantiate(newPlayerSprite, villageReturnPosition.position, Quaternion.identity);
                newPlayerInstance.GetComponent<Animator>().SetBool("isIdle", true); 
            }
            else
            {
                Debug.LogWarning("VillageReturnPosition not found in VillageScene.");
            }
        }
    }
}