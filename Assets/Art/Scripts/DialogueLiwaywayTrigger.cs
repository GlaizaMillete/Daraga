using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueLiwaywayTrigger : MonoBehaviour
{
    public DialogueLiwayway.Dialogue dialogue;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera tagged 'MainCamera'.");
        }

        if (EventSystem.current == null)
        {
            Debug.LogError("No EventSystem found. Add one to the scene.");
        }
    }

    public void TriggerDialogue()
    {
        if (DialogueLiwayway.Instance != null)
        {
            DialogueLiwayway.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueLiwayway instance not found.");
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (mainCamera != null)
                {
                    Vector3 touchPosition = Input.GetTouch(0).position;
                    touchPosition.z = 10;
                    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                    worldPosition.z = 0;

                    Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

                    if (hitCollider != null && hitCollider.gameObject == gameObject)
                    {
                        TriggerDialogue();
                    }
                }
            }
        }
    }
}


/*using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueLiwaywayTrigger : MonoBehaviour
{
    public DialogueLiwayway.Dialogue dialogue;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera tagged 'MainCamera'.");
        }

        if (EventSystem.current == null)
        {
            Debug.LogError("No EventSystem found. Add one to the scene.");
        }
    }

    public void TriggerDialogue()
    {
        if (DialogueLiwayway.Instance != null)
        {
            DialogueLiwayway.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueLiwayway instance not found.");
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (mainCamera != null)
                {
                    Vector3 touchPosition = Input.GetTouch(0).position;
                    touchPosition.z = 10;
                    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                    worldPosition.z = 0;

                    Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

                    if (hitCollider != null && hitCollider.gameObject == gameObject)
                    {
                        TriggerDialogue();
                    }
                }
            }
        }
    }
}una na script*//*

/*using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueLiwaywayTrigger : MonoBehaviour
{
    public DialogueLiwayway.Dialogue dialogue;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Ensure there is a camera tagged 'MainCamera'.");
        }

        if (EventSystem.current == null)
        {
            Debug.LogError("No EventSystem found. Add one to the scene.");
        }
    }

    public void TriggerDialogue()
    {
        if (DialogueLiwayway.Instance != null)
        {
            DialogueLiwayway.Instance.StartDialogue(dialogue);
        }
        else
        {
            Debug.LogError("DialogueLiwayway instance not found.");
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                if (mainCamera != null)
                {
                    Vector3 touchPosition = Input.GetTouch(0).position;
                    touchPosition.z = 10;
                    Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                    worldPosition.z = 0;

                    Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

                    if (hitCollider != null && hitCollider.gameObject == gameObject)
                    {
                        TriggerDialogue();
                    }
                }
            }
        }
    }
}*/ //Pangalawang script to

