using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] string sceneToGoTo;
    [SerializeField] bool setCustomScene;
    [SerializeField] string customScene;
    void Start() {
        #if UNITY_EDITOR
        if (setCustomScene && sceneToGoTo != null && sceneToGoTo != "") {
            SceneManager.LoadScene(customScene);
        } else {
            SceneManager.LoadScene(sceneToGoTo);
        }
        #elif UNITY_STANDALONE
        SceneManager.LoadScene(sceneToGoTo);
        #endif
    }
}
