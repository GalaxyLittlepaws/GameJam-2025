[System.Serializable]
public class GameData{

    //variables here 
    public float SFXVolume;
    public float MusicVolume;
    public float SpeechVolume;
    public int particles;
    public int contrast;
    public bool bloom;
    public bool chromAbb;
    public bool grain;
    public bool vignette;
    public bool screenshake;
    public int font;
    public int currentColor;
    public int textAnim;
    public int textWidth;
    public bool fullscreen;
    public int language;
    public int currentResolution;
    public int textPlacement;
    public bool forceSmallText;
    public bool scrollText;
    public bool startup;
    public string customColour1;
    public string customColour2;
    public string customColour3;
    public string customColour4;
    public string customColour5;

    public GameData() {
        //set variable here
        this.SFXVolume = 5;
        this.MusicVolume = 5;
        this.SpeechVolume = 5;
        this.particles = 0;
        this.contrast = 0;
        this.bloom = true;
        this.chromAbb = true;
        this.grain = true;
        this.vignette = true;
        this.screenshake = true;
        this.font = 0;
        this.currentColor = 0;
        this.textAnim = 0;
        this.textWidth = 5;
        this.fullscreen = true;
        this.language = 0;
        this.currentResolution = 9;
        this.textPlacement = 0;
        this.forceSmallText = false;
        this.scrollText = true;
        this.startup = false;
        this.customColour1 = "blank";
        this.customColour2 = "blank";
        this.customColour3 = "blank";
        this.customColour4 = "blank";
        this.customColour5 = "blank";
    }

}
