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

}
