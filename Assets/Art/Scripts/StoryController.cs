using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public Animator storyAnimator;

    private void Start()
    {
        // Start the story animation
        storyAnimator.Play("IntroAnimationStory");
    }

    public void OnStoryComplete()
    {
        // Transition to the next scene when the story is complete
        SceneManager.LoadScene("NextSceneName");
    }
}
