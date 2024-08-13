using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueContent : MonoBehaviour
{
     public GameObject continueContent;

public void ShowContent()
{
    continueContent.SetActive(true);
}

public void HideContent()
{
    continueContent.SetActive(false);
}
}
