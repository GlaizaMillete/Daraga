using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSwapScript : MonoBehaviour
{
    public GameObject player; // Assign your player GameObject here
    public GameObject[] skins; // Assign your different skin GameObjects here
    private int currentSkinIndex = 0; // Index to keep track of the current skin

    void Start()
    {
        // Ensure the correct skin is active when the scene starts
        UpdateSkin();
    }

    // Call this method when the button is clicked
    public void OnArrowExitDoorButtonClick()
    {
        // Increment the skin index to switch to the next skin
        currentSkinIndex = (currentSkinIndex + 1) % skins.Length; // Loop back to the first skin if at the end
        UpdateSkin();

        // Load the VillageScene
        SceneManager.LoadScene("VillageScene");
    }

    private void UpdateSkin()
    {
        // Disable all skins
        foreach (GameObject skin in skins)
        {
            skin.SetActive(false);
        }

        // Enable the current skin
        skins[currentSkinIndex].SetActive(true);
    }
}
