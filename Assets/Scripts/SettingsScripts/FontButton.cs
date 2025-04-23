using TMPro;
using UnityEngine;

public class FontButton : MonoBehaviour {
    [SerializeField] TextMeshProUGUI tMPro;
    AccessibilityManager accessibilityManager;
    void Start() {
        accessibilityManager = FindAnyObjectByType<AccessibilityManager>();
    }

    void Update() {
        if (accessibilityManager.font == 0) {
            tMPro.text = "Default";
        } else if (accessibilityManager.font == 1) {
            tMPro.text = "Arial";
        } else if (accessibilityManager.font == 2) {
            tMPro.text = "OpenDyslexic";
        } else if (accessibilityManager.font == 3) {
            tMPro.text = "Comic Sans";
        }
    }
    public void Toggle() {
        accessibilityManager.font ++;
        if (accessibilityManager.font > 3) {
            accessibilityManager.font = 0;
        }
    }
}
