using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostSettings : MonoBehaviour {

    [SerializeField] Volume bloom;
    [SerializeField] Volume chromAb;
    [SerializeField] Volume filmGrain;
    [SerializeField] Volume vignette;

    [Header("Contrast")]
    [SerializeField] GameObject highContrast;
    [SerializeField] GameObject lowContrast;
    [SerializeField] List<Volume> highVolumes;
    [SerializeField] List<Volume> lowVolumes;

    AccessibilityManager manager;

    void Start() {
        manager = FindObjectOfType<AccessibilityManager>();
    }

    void Update() {
        bloom.enabled = manager.bloom;
        chromAb.enabled = manager.chromAbb;
        filmGrain.enabled = manager.grain;
        vignette.enabled = manager.vignette;
        Contrast();
    }

    void Contrast() {
        int currentContrast = manager.contrast;

        if (currentContrast > 0) {
            highContrast.SetActive(true);
            lowContrast.SetActive(false);
            foreach(Volume e in highVolumes) {
                if (highVolumes.IndexOf(e) + 1 == currentContrast) {
                    e.enabled = true;
                } else {
                    e.enabled = false;
                }
            }

        } else if (currentContrast < 0) {
            highContrast.SetActive(false);
            lowContrast.SetActive(true);
            foreach(Volume e in lowVolumes) {
                if (lowVolumes.IndexOf(e) + 1 == Mathf.Abs(currentContrast)) {
                    e.enabled = true;
                } else {
                    e.enabled = false;
                }
            }

        } else if (currentContrast == 0) {
            highContrast.SetActive(false);
            lowContrast.SetActive(false);
        }
    }
}
