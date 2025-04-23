using TMPro;
using UnityEngine;


public class TextMeshSettings : MonoBehaviour {

    AccessibilityManager manager;
    [SerializeField] bool isUI = true;
    [SerializeField] bool useDefaultListedColour = true;
    [SerializeField] bool negateColourEffect = false;
    TextMeshProUGUI TeMProUI;
    TextMeshPro TeMPro;
    Color defaultColor;
    
    public void SetNegate(bool setting) {
        negateColourEffect = setting;
    }
    void Start() {
        if (isUI) {
            TeMProUI = GetComponent<TextMeshProUGUI>();
            defaultColor = TeMProUI.color;
        } else {
            TeMPro = GetComponent<TextMeshPro>();
            defaultColor = TeMPro.color;
        }
        manager = FindAnyObjectByType<AccessibilityManager>();
    }
    void Update() {
        //font
        if (isUI) {
            TeMProUI.font = manager.SetFont();
        } else {
            TeMPro.font = manager.SetFont();
        }
        
        if (negateColourEffect) {
            return;
        }

        //colour
        if (isUI) {
            if (manager.currentColour == 0) {
                //this is default
                if (!useDefaultListedColour) {
                    TeMProUI.color = defaultColor;
                } else {
                    TeMProUI.color = manager.colourList[manager.currentColour];
                }
            } else {
                TeMProUI.color = manager.colourList[manager.currentColour];
            }
        } else {
            if (manager.currentColour == 0) {
                //this is default
                if (!useDefaultListedColour) {
                    TeMPro.color = defaultColor;
                } else {
                    TeMPro.color = manager.colourList[manager.currentColour];
                }
            } else {
                TeMPro.color = manager.colourList[manager.currentColour];
            }
        }
    }
        
}
