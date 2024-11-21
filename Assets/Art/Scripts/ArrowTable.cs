using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowTable : MonoBehaviour
{
    public GameObject arrowTableButton; // ArrowTable button
    public Animator receiveBoxAnimator; // Animator for the receive box
    public string jarAssembleSceneName = "JarAssemble"; // Name of the JarAssemble scene
    public GameObject joystick;        // Reference to the joystick UI
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


/*using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowTable : MonoBehaviour
{
    public GameObject arrowTableButton; // ArrowTable button
    public Animator receiveBoxAnimator; // Animator for the receive box
    public string jarAssembleSceneName = "JarAssemble"; // Name of the JarAssemble scene
    public GameObject joystick;        // Reference to the joystick UI

    private void Start()
    {
        // Ensure arrow table button is active at the start
        arrowTableButton.SetActive(true);

        // Disable the receive box animator initially
        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(false);
        }
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
}una na script*/

/*using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowTable : MonoBehaviour
{
    public GameObject arrowTableButton; // ArrowTable button
    public Animator receiveBoxAnimator; // Animator for the receive box
    public string jarAssembleSceneName = "JarAssemble"; // Name of the JarAssemble scene
    public GameObject joystick;        // Reference to the joystick UI

    private void Start()
    {
        // Ensure arrow table button is active at the start
        arrowTableButton.SetActive(true);

        // Disable the receive box animator initially
        if (receiveBoxAnimator != null)
        {
            receiveBoxAnimator.gameObject.SetActive(false);
        }
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
}*/

