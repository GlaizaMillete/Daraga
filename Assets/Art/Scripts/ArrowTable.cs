using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ArrowTable : MonoBehaviour
{
    public GameObject arrowTableButton; // ArrowTable button
    public Animator receiveBoxAnimator; // Animator for the receive box
    public string jarAssembleSceneName = "JarAssemble"; // Name of the JarAssemble scene
    public GameObject joystick; // Reference to the joystick UI
    private DialogueLiwayway dialogueLiwayway;

    private void Start()
    {
        // Initially disable the arrow table button
        arrowTableButton.SetActive(false);

        // Get the instance of DialogueLiwayway
        dialogueLiwayway = DialogueLiwayway.Instance;

        // Subscribe to the dialogue end event to enable the button
        if (dialogueLiwayway != null)
        {
            dialogueLiwayway.OnDialogueEnd += EnableArrowTableButton;
        }

        // Disable the receive box animator initially
        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            Debug.Log("Touch Position: " + touchPosition);  // Debugging touch position

            // Check if the touch overlaps the ArrowTable button
            if (IsTouchOverButton(arrowTableButton, touchPosition))
            {
                Debug.Log("ArrowTable button touched!");  // Debugging touch on button
                OnArrowTableButtonClicked();
            }

        }
    }

    private bool IsTouchOverButton(GameObject button, Vector2 touchPosition)
    {
        if (button == null) return false;

        // Get the RectTransform of the button
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        if (rectTransform == null) return false;

        // Convert touch position to local UI coordinates
        Vector2 localPoint;
        Canvas canvas = button.GetComponentInParent<Canvas>(); // Get the canvas the button is on
        if (canvas == null) return false;

        // Use RectTransformUtility for coordinate conversion
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rectTransform, 
                touchPosition, 
                canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : Camera.main, 
                out localPoint))
        {
            // Check if the touch point is within the button's bounds
            return rectTransform.rect.Contains(localPoint);
        }

        return false;
    }

    private void EnableArrowTableButton()
    {
        // Enable the arrow table button once the dialogue ends
        arrowTableButton.SetActive(true);
    }

    public void OnArrowTableButtonClicked()
    {
        // Save player and camera position before transitioning
        SavePlayerAndCameraState();

        // Hide the joystick during the transition
        if (joystick != null)
        {
            joystick.SetActive(false);
        }

        // Load the JarAssemble scene
        SceneManager.LoadScene(jarAssembleSceneName);
    }

    private void SavePlayerAndCameraState()
    {
        Vector3 playerPosition = transform.position;
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

        Vector3 cameraPosition = Camera.main.transform.position;
        PlayerPrefs.SetFloat("CameraPosX", cameraPosition.x);
        PlayerPrefs.SetFloat("CameraPosY", cameraPosition.y);
        PlayerPrefs.SetFloat("CameraPosZ", cameraPosition.z);

        PlayerPrefs.Save();
    }
}
