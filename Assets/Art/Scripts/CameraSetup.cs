using UnityEngine;
using Cinemachine;

public class CameraSetup : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    private CinemachineVirtualCamera cinemachineCamera;

    private void Start()
    {
        // Find the Cinemachine camera in the scene
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();

        // Ensure the player is assigned as the Follow target
        if (cinemachineCamera != null && player != null)
        {
            cinemachineCamera.Follow = player.transform;
        }
    }
}
