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
using UnityEngine.InputSystem;
using UnityEngine.UI; // Ensure you have this for UI elements

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
            if (jarPiece != null)
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

   void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch != null)
        {
            if (Touchscreen.current.primaryTouch.press.isPressed)
            {
                Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                Debug.Log($"Touch detected at: {touchPosition}");

                foreach (GameObject jarPiece in jarPieces)
                {
                    if (jarPiece != null)
                    {
                        RectTransform rectTransform = jarPiece.GetComponent<RectTransform>();
                        if (rectTransform != null && IsTouchInsideRect(touchPosition, rectTransform))
                        {
                            Debug.Log($"Jar piece touched: {jarPiece.name}");
                            AssembleJarPiece(System.Array.IndexOf(jarPieces, jarPiece));
                            break;
                        }
                    }
                }

                if (completeButton != null)
                {
                    RectTransform buttonRect = completeButton.GetComponent<RectTransform>();
                    if (buttonRect != null && IsTouchInsideRect(touchPosition, buttonRect) && completeButton.interactable)
                    {
                        Debug.Log("Complete button touched!");
                        OnCompleteButtonClicked();
                    }
                }
            }
        }
    }



    // Helper method to check if the touch is inside the bounds of the UI element
   private bool IsTouchInsideRect(Vector2 touchPosition, RectTransform rectTransform)
    {
        Canvas canvas = rectTransform.GetComponentInParent<Canvas>();
        if (canvas == null) return false;

        // Convert screen point to local point in the RectTransform
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform, 
                touchPosition, 
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main, 
                out Vector2 localPoint))
        {
            // Log for debugging purposes
            Debug.Log($"Touch Position: {touchPosition}, Local Position: {localPoint}");
            Debug.Log($"Rect Bounds: {rectTransform.rect}");
            return rectTransform.rect.Contains(localPoint);
        }

        return false;
    }



    // Method to assemble the jar piece (you can add your custom logic here)
    private void AssembleJarPiece(int index)
    {
        // Example of assembling logic: you could increase the count or show animations
        assembledPieces++;
        Debug.Log("Jar piece assembled: " + index);

        if (assembledPieces == jarPieces.Length)
        {
            isJarComplete = true;
            TriggerReceiveBoxAnimation(); // Trigger animation when all pieces are assembled
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

    // Called when the "Complete" button is clicked
    public void OnCompleteButtonClicked()
    {
        Debug.Log("Complete button clicked!");
        OnJarAssemblyComplete();
    }

    // When jar assembly is complete
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

    // Method to return to LiwaywayHouse scene
    public void ReturnToLiwaywayHouse()
    {
        Debug.Log("Returning to LiwaywayHouse scene.");

        // Re-enable joystick when returning to LiwaywayHouse scene
        if (joystick != null)
        {
            joystick.SetActive(true);
        }

        // Load the LiwaywayHouse scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(liwaywayHouseSceneName);
    }
}
