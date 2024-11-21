/*using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JarAssemble : MonoBehaviour
{
    public GameObject jarOutline;
    public GameObject[] jarPieces;
    public Animator receiveBoxAnimator;
    public string liwaywayHouseSceneName = "LiwaywayHouse";
    public GameObject joystick; // Reference to the joystick GameObject
    public Button completeButton; // Reference to the "Complete" button

    private int assembledPieces = 0;
    private bool isJarComplete = false;

    public void Start()
    {
        // Disable the joystick for JarAssemble scene
        if (joystick != null)
        {
            joystick.SetActive(false);
        }

        // Disable the Complete button initially
        if (completeButton != null)
        {
            completeButton.interactable = false; // Lock the button
        }

        // Activate jar pieces and outline
        foreach (GameObject jarPiece in jarPieces)
        {
            jarPiece.SetActive(true);
        }

        if (jarOutline != null)
        {
            jarOutline.SetActive(true);
        }

        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(false);
        }
    }

    // New method that triggers the receive box animation and unlocks the button after
    public void TriggerReceiveBoxAnimation()
    {
        // Play the receive box animation
        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(true);
            receiveBoxAnimator.SetTrigger("Show"); // Trigger animation
        }

        // Wait for the animation to complete before unlocking the button
        Invoke(nameof(UnlockCompleteButton), 2f); // 2f is the delay (adjust as necessary)
    }

    // Method to unlock the 'Complete' button after animation completes
    private void UnlockCompleteButton()
    {
        if (completeButton != null)
        {
            completeButton.interactable = true; // Unlock the button
            Debug.Log("Complete button unlocked.");
        }
    }

    public void OnCompleteButtonClicked()
    {
        Debug.Log("Jar assembly complete!");

        // Enable joystick when the scene is ready for transition
        if (joystick != null)
        {
            joystick.SetActive(true);
        }

        // Transition to the Liwayway House scene
        SceneManager.LoadScene(liwaywayHouseSceneName);
    }

    public void UpdateJarPieceCount(int newPieceCount)
    {
        assembledPieces = newPieceCount;

        if (assembledPieces >= jarPieces.Length)
        {
            isJarComplete = true;
            TriggerReceiveBoxAnimation();
        }
    }
}*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Add this to reference UI elements like buttons

public class JarAssemble : MonoBehaviour
{
    public GameObject jarOutline;
    public GameObject[] jarPieces;
    public Animator receiveBoxAnimator;
    public string liwaywayHouseSceneName = "LiwaywayHouse";
    public GameObject joystick; // Reference to the joystick GameObject
    public Button completeButton; // Reference to the "Complete" button

    private int assembledPieces = 0;
    private bool isJarComplete = false;

    public void Start()
    {
        // Disable the joystick for JarAssemble scene
        if (joystick != null)
        {
            joystick.SetActive(false);
        }

        // Disable the Complete button initially
        if (completeButton != null)
        {
            completeButton.interactable = false; // Lock the button
        }

        // Activate jar pieces and outline
        foreach (GameObject jarPiece in jarPieces)
        {
            jarPiece.SetActive(true);
        }

        if (jarOutline != null)
        {
            jarOutline.SetActive(true);
        }

        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LiwaywayHouse" && joystick != null)
        {
            joystick.SetActive(true);  // Ensure joystick is active when returning to LiwaywayHouse
        }
    }

    // New method that triggers the receive box animation and unlocks the button after
    public void TriggerReceiveBoxAnimation()
    {
        // Play the receive box animation
        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(true);
            receiveBoxAnimator.SetTrigger("Show"); // Trigger animation
        }

        // Wait for the animation to complete before unlocking the button
        Invoke(nameof(UnlockCompleteButton), 2f); // 2f is the delay (adjust as necessary)
    }

    // Method to unlock the 'Complete' button after animation completes
    private void UnlockCompleteButton()
    {
        if (completeButton != null)
        {
            completeButton.interactable = true; // Unlock the button
            Debug.Log("Complete button unlocked.");
        }
    }

    public void OnCompleteButtonClicked()
    {
        Debug.Log("Complete button clicked!");
        OnJarAssemblyComplete();
    }

    public void OnJarAssemblyComplete()
    {
        Debug.Log("Jar assembly complete!");

        // Show the receive box animation
        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(true);
            receiveBoxAnimator.SetTrigger("Show");
        }

        // Save the jar assembly state
        PlayerPrefs.SetInt("JarAssembled", 1);

        // Delay for the animation before returning
        Invoke(nameof(ReturnToLiwaywayHouse), 2f);
    }

    public void ReturnToLiwaywayHouse()
    {
        Debug.Log("Returning to LiwaywayHouse scene.");

        // Re-enable joystick when returning to LiwaywayHouse scene
        if (joystick != null)
        {
            joystick.SetActive(true);
        }

        // Load the LiwaywayHouse scene
        SceneManager.LoadScene(liwaywayHouseSceneName);
    }
}
