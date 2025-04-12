[System.Serializable]
public class GameData{

    //variables here 
    public float SFXVolume;
    public float MusicVolume;
    public int font;
    public int currentColor;
    public bool fullscreen;
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
        this.font = 0;
        this.currentColor = 0;
        this.fullscreen = true;
        this.startup = false;
        this.customColour1 = "blank";
        this.customColour2 = "blank";
        this.customColour3 = "blank";
        this.customColour4 = "blank";
        this.customColour5 = "blank";
    }

}
