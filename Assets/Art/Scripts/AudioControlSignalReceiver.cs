using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource audioSource;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is SignalEmitter signalEmitter)
        {
            // Assuming you use a specific signal to pause or resume
            if (signalEmitter.name == "PauseAudio")
            {
                audioSource.Pause();
            }
            else if (signalEmitter.name == "ResumeAudio")
            {
                audioSource.UnPause();
            }
        }
    }
}
