using UnityEngine;

[System.Serializable]
public class Action {
    public int index = 0;

    //set visibility
    public bool visiState;
    public SpriteRenderer visiRenderer;

    //animate
    public int animType;
    public Animator animAnimator;
    public string animTrigger;
    public int animInt;
    public bool animBool;

    //transform
    public int transType;
    public Vector3 transNew;
    public GameObject transObject;
    public float transTime;
    public bool waitForTransform;
    //set active
    public GameObject actObject;
    public bool actState;

    //interactable state
    public bool intState;

    //change hotspot
    public Interactable hotInteract;
    public bool hotState;

    //wait
    public float waitTime;

    //comment
    public string comment;

    //add inventory
    public InventoryObject addInvObj;

    //remove inventory
    public InventoryObject remInvObj;

    //check inventory
    public InventoryObject checkInvObj;
    public ActionList checkSkipTo;
    public int checkSkipTrue;

    //fade camera
    public float camFadeTime;
    public float camFadeAmount;

    //fade camera
    public float spriteFadeTime;
    public float spriteFadeAmount;
    public SpriteRenderer spriteFade;

    //change scene
    public int useID;
    public int sceneID;
    public string sceneName;

    //playsound
    public AudioManager audioManager;

    //check finish
    public ActionList listToPlay;

    //unlock colour
    public int colourToUnlock;

}
