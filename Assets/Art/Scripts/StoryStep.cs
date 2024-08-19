using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryStep : MonoBehaviour
{
    public GameObject nextStoryStep; // Reference to the next GameObject in the sequence
    public string sceneToLoad; // Leave empty except for the last step

    // Rename the method to be more unique
    public void StoryStep_OnAnimationComplete() // Call this function via an Animation Event
    {
        StartCoroutine(ProceedToNextStep());
    }

    private IEnumerator ProceedToNextStep()
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
            // Wait until the current animation state is completely finished
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            float remainingTime = stateInfo.length - (stateInfo.normalizedTime * stateInfo.length);
            yield return new WaitForSeconds(remainingTime);
        }

        if (nextStoryStep != null)
        {
            nextStoryStep.SetActive(true); // Activate the next story part
            Animator nextAnimator = nextStoryStep.GetComponent<Animator>();
            if (nextAnimator != null)
            {
                nextAnimator.Play(nextAnimator.GetCurrentAnimatorStateInfo(0).fullPathHash);
            }
        }
        else if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // If this is the last story step, load the next scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
