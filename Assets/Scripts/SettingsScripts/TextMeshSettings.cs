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
        
        if (isUI) {
            if (TeMProUI == null) {
                TeMProUI = GetComponent<TextMeshProUGUI>();
                defaultColor = TeMProUI.color;
            }
            TeMProUI.font = manager.SetFont();
            if (!negateColourEffect) {
                if (manager.currentColour == 0) {
                TeMProUI.overrideColorTags = false;
                if (!useDefaultListedColour) {
                    TeMProUI.color = manager.colourList[0];
                } else {
                    TeMProUI.color = defaultColor;
                }
            } else if (manager.currentColour == 1) {
                TeMProUI.overrideColorTags = true;
                if (!useDefaultListedColour) {
                    TeMProUI.color = manager.colourList[0];
                } else {
                    TeMProUI.color = defaultColor;
                }
            } else {
                TeMProUI.overrideColorTags = true;
                TeMProUI.color = manager.colourList[manager.currentColour + -1];
            }
            }
            

        } else {
            if (TeMPro == null) {
                TeMPro = GetComponent<TextMeshPro>();
                defaultColor = TeMPro.color;
            }
            TeMPro.font = manager.SetFont();
            if (!negateColourEffect) {
                if (manager.currentColour == 0) {
                    TeMPro.overrideColorTags = false;
                    if (!useDefaultListedColour) {
                        TeMPro.color = manager.colourList[0];
                    } else {
                        TeMPro.color = defaultColor;
                    }
                } else if (manager.currentColour == 1) {
                    TeMPro.overrideColorTags = true;
                    if (!useDefaultListedColour) {
                        TeMPro.color = manager.colourList[0];
                    } else {
                        TeMPro.color = defaultColor;
                    }
                } else {
                    TeMPro.overrideColorTags = true;
                    TeMPro.color = manager.colourList[manager.currentColour + -1];
                }
            }
        }
    }
        
}
