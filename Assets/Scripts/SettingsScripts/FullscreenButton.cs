using TMPro;
using UnityEngine;

public class FullscreenButton : MonoBehaviour {
    [SerializeField] TextMeshProUGUI tMPro;
    AccessibilityManager accessibilityManager;
    void Start() {
        accessibilityManager = FindAnyObjectByType<AccessibilityManager>();
    }

    void Update() {
        if (accessibilityManager.fullscreen)
            tMPro.text = "Fullscreen";
        else
            tMPro.text = "Windowed";
    }

    public void Toggle() {
        if (accessibilityManager.fullscreen)
            accessibilityManager.TurnOffFullscreen();
        else
            accessibilityManager.TurnOnFullscreen();
    }
}
