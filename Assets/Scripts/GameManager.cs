using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool interactionEnabled = true;
    void Awake() {
        DontDestroyOnLoad(this);
    }

    void Update() {
        
    }
    
}
