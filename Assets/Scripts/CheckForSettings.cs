using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForSettings : MonoBehaviour {
    void Start() {
        if (FindAnyObjectByType<GameManager>() == null) {
            SceneManager.LoadScene("Bootstrapper");
        }
    }

    void Update() {
        
    }
}
