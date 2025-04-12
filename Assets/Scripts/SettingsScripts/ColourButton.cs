using TMPro;
using UnityEngine;

public class ColourButton : MonoBehaviour {
    [SerializeField] TextMeshProUGUI tMPro;
    AccessibilityManager accessibilityManager;
    void Start() {
        accessibilityManager = FindAnyObjectByType<AccessibilityManager>();
    }

    void Update() {
        
    }
}
