using UnityEngine;

public class PlayerPositionLoader : MonoBehaviour
{
    void Start()
    {
        // Set the player’s position based on saved coordinates
        float x = PlayerPrefs.GetFloat("PlayerX", transform.position.x);
        float y = PlayerPrefs.GetFloat("PlayerY", transform.position.y);
        float z = PlayerPrefs.GetFloat("PlayerZ", transform.position.z);

        transform.position = new Vector3(x, y, z);
    }
}
