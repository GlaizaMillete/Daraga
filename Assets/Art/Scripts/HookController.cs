using System.Collections;
using UnityEngine;

public class HookController : MonoBehaviour
{
    public float hookSpeed = 2f;
    public float riseSpeed = 5f;
    public float minY = -5f;
    public float maxY = 1f;

    private bool isRising = false;
    private bool isFishCaught = false;
    private GameObject caughtFish;
    public PopupController popupController; // Reference to the PopupController

    void Update()
    {
        if (isFishCaught)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            if (!isRising)
            {
                isRising = true;
            }
        }

        if (!isRising)
        {
            transform.Translate(Vector3.down * hookSpeed * Time.deltaTime);
            if (transform.position.y <= minY)
            {
                transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            }
        }
        else
        {
            transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            if (transform.position.y >= maxY)
            {
                transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
                isRising = false;

                // If a fish is caught, notify the popup controller
                if (isFishCaught)
                {
                    popupController.OnFishCaught(); // Notify the popup
                }
            }
        }
    }

   void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Fish") && isRising)
    {
        isFishCaught = true;
        caughtFish = collision.gameObject;
        caughtFish.transform.SetParent(transform);
        caughtFish.transform.localPosition = Vector3.zero;
        Debug.Log("Fish Caught!"); 

        if (popupController != null)
        {
            // Start the popup delay from the HookController (which should be an active object)
            StartCoroutine(popupController.ShowPopupAfterDelay()); 
        }
        else
        {
            Debug.LogWarning("PopupController is not assigned!");
        }
    }
}
}


