using TMPro;
using UnityEngine;

public class SoundButton : MonoBehaviour {
    [SerializeField] bool isSFX;
    [SerializeField] bool doText;
    [SerializeField] TextMeshProUGUI tMPro;
    AccessibilityManager accessibilityManager;
    void Start() {
        accessibilityManager = FindAnyObjectByType<AccessibilityManager>();
    }

    void Update() {
        if (!doText) {
            return;
        }
        if (isSFX) {
            tMPro.text = accessibilityManager.SFX.ToString();
        } else {
            tMPro.text = accessibilityManager.music.ToString();
        }
    }
    public void Up() {
        if (isSFX) {
            accessibilityManager.SFX ++;
            if (accessibilityManager.SFX > 10) {
                accessibilityManager.SFX = 10;
            }
        } else {
            accessibilityManager.music ++;
            if (accessibilityManager.music > 10) {
                accessibilityManager.music = 10;
            }
        }
    }

    public void Down() {
        if (isSFX) {
            accessibilityManager.SFX --;
            if (accessibilityManager.SFX < 0) {
                accessibilityManager.SFX = 0;
            }
        } else {
            accessibilityManager.music --;
            if (accessibilityManager.music < 0) {
                accessibilityManager.music = 0;
            }
        }
    }
}
