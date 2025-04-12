using TMPro;
using UnityEngine;

public class ColourButton : MonoBehaviour {
    [SerializeField] TextMeshProUGUI tMPro;
    AccessibilityManager accessibilityManager;
    [SerializeField] TextMeshProUGUI colourVal;
    void Start() {
        accessibilityManager = FindAnyObjectByType<AccessibilityManager>();
    }

    public void Cycle() {
        accessibilityManager.currentColour++;
        if (accessibilityManager.currentColour == accessibilityManager.colourList.Count) {
            accessibilityManager.currentColour = 0;
        }
    }
    void Update() {
        if(accessibilityManager.currentColour == 0) {
            colourVal.text = "Default";
        } else if(accessibilityManager.currentColour == 1) {
            colourVal.text = "White";
        } else {
            colourVal.text = accessibilityManager.colourList[accessibilityManager.currentColour].ToString();
        }
    }
}
