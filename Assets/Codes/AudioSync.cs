using UnityEngine;
using System.Collections.Generic;

public class AudioSync : MonoBehaviour
{
    public static AudioSync Instance { get; private set; }
    private List<AudioSource> activeSources = new List<AudioSource>();
    private float syncTime = 0f;
    private bool isPlaying = false;
    
    
    [Range(0.01f, 0.1f)]
    public float syncThreshold = 0.03f;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void RegisterAudioSource(AudioSource source)
    {
        if (source == null) return;
        
        
        source.loop = true;
        
        if (!isPlaying || activeSources.Count == 0)
        {
            source.Play();
            syncTime = 0f;
            isPlaying = true;
            activeSources.Add(source);
        }
        else
        {
            source.time = syncTime;
            source.Play();
            activeSources.Add(source);
            
        }
    }
    
    public void UnregisterAudioSource(AudioSource source)
    {
        if (activeSources.Contains(source))
        {
            activeSources.Remove(source);
            
            if (activeSources.Count == 0)
            {
                isPlaying = false;
                syncTime = 0f;
                Debug.Log("所有音频源已移除，重置同步系统");
            }
        }
    }
    
    void Update()
    {
        if (!isPlaying || activeSources.Count == 0) return;
        
        for (int i = activeSources.Count - 1; i >= 0; i--)
        {
            if (activeSources[i] == null)
            {
                activeSources.RemoveAt(i);
            }
        }
        
        if (activeSources.Count == 0)
        {
            isPlaying = false;
            syncTime = 0f;
            return;
        }
        
        syncTime = activeSources[0].time;
        
        for (int i = 1; i < activeSources.Count; i++)
        {
            if (Mathf.Abs(activeSources[i].time - syncTime) > syncThreshold)
            {
                activeSources[i].time = syncTime;
            }
        }
    }
}