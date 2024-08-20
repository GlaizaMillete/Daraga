using UnityEngine;

public class ForestSceneSetup : MonoBehaviour
{
    public GameObject joystick;
    public PlayerMovement playerMovement;

    void Start()
    {
        // Ensure the joystick is active
        joystick.SetActive(true);

        // Link the joystick to the player movement script
        playerMovement.joystick = joystick.GetComponent<Joystick>();
    }
}
