using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] bool isSFX = true;
    AudioSource source;
    [SerializeField] AudioClip clip;
    AccessibilityManager manager;
    void Start() {
        manager = FindAnyObjectByType<AccessibilityManager>();
        source = GetComponent<AudioSource>();
    }

    void Update() {
        if (isSFX)
            source.volume = manager.SFX/10;
        else
            source.volume = manager.music/10;
    }
    public void Play() {
        source.clip = clip;
        source.Play();
    }
}
