using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool interactionEnabled = true;
    public Texture2D cursor;
    public Texture2D currentCursor;
    public bool bearPuzzleDone = false;
    public bool cupPuzzleDone = false;
    void Awake() {
        DontDestroyOnLoad(this);
    }

    void Update() {
        Cursor.SetCursor(currentCursor, new Vector2(64,64), CursorMode.ForceSoftware);
    }
    
}
