using UnityEngine;
public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource == null)
        {
            return;
        }
        
        if (AudioSync.Instance != null)
        {
            AudioSync.Instance.RegisterAudioSource(audioSource);
                    }
    }
    
    void OnDestroy()
    {
        if (AudioSync.Instance != null && audioSource != null)
        {
            AudioSync.Instance.UnregisterAudioSource(audioSource);
        }
    }
}