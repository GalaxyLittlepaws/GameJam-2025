using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] string sceneToGoTo;
    [SerializeField] bool setCustomScene;
    [SerializeField] string customScene;
    void Start() {
        if (setCustomScene && sceneToGoTo != null && sceneToGoTo != "") {
            SceneManager.LoadScene(customScene);
        } else {
            SceneManager.LoadScene(sceneToGoTo);
        }
    }
}
