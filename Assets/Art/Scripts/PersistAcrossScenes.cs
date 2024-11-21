using UnityEngine;

public class PersistAcrossScenes : MonoBehaviour
{
    private void Awake()
    {
        // Ensure this object is not duplicated
        if (FindObjectsOfType<PersistAcrossScenes>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
