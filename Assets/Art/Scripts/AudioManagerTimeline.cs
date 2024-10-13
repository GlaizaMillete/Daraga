using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class AudioManagerTimeline : MonoBehaviour
{
    public AudioSource[] audioSources; // Array of audio sources to be managed
    private AudioSource currentAudioSource;

    void Start()
    {
        // Initialize with the first audio source
        if (audioSources.Length > 0)
        {
            currentAudioSource = audioSources[0];
        }
    }

    // Call this method from the Timeline's PlayableDirector or any event in Timeline
    public void PlayAudio(int index)
    {
        // Check if the index is valid and if the audio source is different from the current one
        if (index >= 0 && index < audioSources.Length && currentAudioSource != audioSources[index])
        {
            // Fade out the current audio source
            if (currentAudioSource != null && currentAudioSource.isPlaying)
            {
                StartCoroutine(FadeOutAudio(currentAudioSource));
            }

            // Play the new audio source
            currentAudioSource = audioSources[index];
            currentAudioSource.Play();
        }
    }

    private System.Collections.IEnumerator FadeOutAudio(AudioSource audioSource)
    {
        float startVolume = audioSource.volume;

        // Gradually reduce the volume
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 1.0f; // 1 second fade out
            yield return null;
        }

        // Stop the audio when fully faded out
        audioSource.Stop();
        audioSource.volume = startVolume; // Reset volume for future playbacks
    }
}
