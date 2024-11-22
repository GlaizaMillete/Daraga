using UnityEngine;
using UnityEngine.EventSystems;

public class WorldSpaceCanvasButtonHandler : MonoBehaviour, IPointerClickHandler
{
    // List of buttons to enable click detection
    public GameObject[] buttons;

    // Start is called before the first frame update
    public void Start()
    {
        foreach (var button in buttons)
        {
            // Ensure that each button has a RaycastTarget enabled for it to detect clicks
            var image = button.GetComponent<UnityEngine.UI.Image>();
            if (image != null)
            {
                image.raycastTarget = true;
            }

            var buttonComponent = button.GetComponent<UnityEngine.UI.Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => OnButtonClicked(button.name));
            }
        }
    }

    // This method gets triggered when a button is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // This method will trigger when the button is clicked
        Debug.Log("Button clicked in World Space!");
    }

    // This is to handle button click logic if required
    private void OnButtonClicked(string buttonName)
    {
        Debug.Log($"{buttonName} button clicked!");
    }
}
