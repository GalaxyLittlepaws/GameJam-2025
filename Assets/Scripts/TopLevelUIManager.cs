using UnityEngine;
using DG.Tweening;

public class TopLevelUIManager : MonoBehaviour {
    
    [SerializeField] CanvasGroup fader;
    void Awake() {
        DontDestroyOnLoad(this);
    }
    public void Fade(float fadeAmount, float fadeTime) {
        fader.DOFade(fadeAmount, fadeTime);
    }
}
