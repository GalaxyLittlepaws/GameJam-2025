using UnityEngine;


public class GameManager : MonoBehaviour
{
    public bool interactionEnabled = true;
    public Texture2D cursor;
    public Texture2D currentCursor;
    void Awake() {
        DontDestroyOnLoad(this);
    }

    void Update() {
        Cursor.SetCursor(currentCursor, new Vector2(0,0), CursorMode.ForceSoftware);
    }
    
}
