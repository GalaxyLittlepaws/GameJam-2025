using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccessibilityManager : MonoBehaviour, IDataPersitence {

    public void SaveData(GameData data) {

        data.font = this.font;
        data.currentColor = this.currentColour;
        data.customColour1 = this.customColour1;
        data.customColour2 = this.customColour2;
        data.customColour3 = this.customColour3;
        data.customColour4 = this.customColour4;
        data.customColour5 = this.customColour5;
        data.SFXVolume = this.SFX;
        data.MusicVolume = this.music;
        data.fullscreen = this.fullscreen;
        data.startup = this.startup;

    }

    public void LoadData(GameData data) {

        this.font = data.font;
        this.currentColour = data.currentColor;
        this.customColour1 = data.customColour1;
        this.customColour2 = data.customColour2;
        this.customColour3 = data.customColour3;
        this.customColour4 = data.customColour4;
        this.customColour5 = data.customColour5;
        this.SFX = data.SFXVolume;
        this.music = data.MusicVolume;
        this.fullscreen = data.fullscreen;
        this.startup = data.startup;

    }

    [Header("Text Settings")]

    [SerializeField] List<TMP_FontAsset> fontList;
    [SerializeField] public int font = 0;
    [SerializeField] public List<Color> colourList;
        /*
        text colour
        0 = default
        1 = constant (no highlighting)
        3 = white
        4 = custom
    */
    [SerializeField] public int currentColour = 0;

    /*
        text animations
        0 = default
        1 = reduced
        2 = Off
    */

    [SerializeField] public string customColour1 = "blank";
    [SerializeField] public string customColour2 = "blank";
    [SerializeField] public string customColour3 = "blank";
    [SerializeField] public string customColour4 = "blank";
    [SerializeField] public string customColour5 = "blank";


    [Header("Sounds Settings")]
    [SerializeField] public float SFX = 5;
    [SerializeField] public float music = 5;

    [Header("Game Settings")]
    [SerializeField] public bool fullscreen = true;

    [SerializeField] public bool startup = false;

    public TMP_FontAsset SetFont() {
        return fontList[font];
    }
    DataPersistenceManager saveManager; 
    void Awake() {
        DontDestroyOnLoad(this);
    }
    void Start() {
        
        saveManager = FindAnyObjectByType<DataPersistenceManager>();
        SetCustomColours();
    }

    void Update() {
        SetSound();
        #if !PLATFORM_WEBGL && !UNITY_WEBGL
        saveManager.SaveGame();
        #endif

    }
    public void TurnOnFullscreen() {   
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        fullscreen = true;
    }

    public void TurnOffFullscreen() {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        fullscreen = false;
    }

    public void SetSound() {
       
    }

    void SetCustomColours() {
        if (customColour1.ToLower() != "blank" && customColour1 != null && customColour1 != "") {
            Color customColor;
            ColorUtility.TryParseHtmlString(customColour1, out customColor);
            customColor.a = 1;
            colourList.Add(customColor);
        }
        if (customColour2.ToLower() != "blank" && customColour2 != null && customColour2 != "") {
            Color customColor;
            ColorUtility.TryParseHtmlString(customColour2, out customColor);
            customColor.a = 1;
            colourList.Add(customColor);
        }
        if (customColour3.ToLower() != "blank" && customColour3 != null && customColour3 != "") {
            Color customColor;
            ColorUtility.TryParseHtmlString(customColour3, out customColor);
            customColor.a = 1;
            colourList.Add(customColor);
        }
        if (customColour4.ToLower() != "blank" && customColour4 != null && customColour4 != "") {
            Color customColor;
            ColorUtility.TryParseHtmlString(customColour4, out customColor);
            customColor.a = 1;
            colourList.Add(customColor);
        }
        if (customColour5.ToLower() != "blank" && customColour5 != null && customColour5 != "") {
            Color customColor;
            ColorUtility.TryParseHtmlString(customColour5, out customColor);
            customColor.a = 1;
            colourList.Add(customColor);
        }
    }
}
