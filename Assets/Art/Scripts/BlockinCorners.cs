using UnityEngine;

public class PlaceBlocksInCorners : MonoBehaviour
{
    public GameObject blockPrefab; // Assign the block prefab here
    public float xBoundary = 5f;   // The x boundary of your scene
    public float yBoundary = 5f;   // The y boundary of your scene

    void Start()
    {
        PlaceBlockAtCorner(new Vector3(-xBoundary, yBoundary, 0)); // Top-left
        PlaceBlockAtCorner(new Vector3(xBoundary, yBoundary, 0));  // Top-right
        PlaceBlockAtCorner(new Vector3(-xBoundary, -yBoundary, 0)); // Bottom-left
        PlaceBlockAtCorner(new Vector3(xBoundary, -yBoundary, 0));  // Bottom-right
    }

    void PlaceBlockAtCorner(Vector3 position)
    {
        // Instantiate the block at the given position
        Instantiate(blockPrefab, position, Quaternion.identity);
    }
}
