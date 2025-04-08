using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool interactionEnabled = true;
    public Texture2D cursor;
    void Awake() {
        DontDestroyOnLoad(this);
    }

    void Update() {
        
    }
    
}
