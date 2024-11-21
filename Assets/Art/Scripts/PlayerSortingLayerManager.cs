using UnityEngine;

public class PlayerSortingLayerManager : MonoBehaviour
{
    [SerializeField] private string playerSortingLayerName = "PlayerLayer"; // Desired sorting layer for the player

    private void Start()
    {
        // Set the sorting layer when the scene loads
        UpdatePlayerSortingLayer();
    }

    public void UpdatePlayerSortingLayer()
    {
        // Find the player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
            {
                playerRenderer.sortingLayerName = playerSortingLayerName;
            }
        }
    }
}
