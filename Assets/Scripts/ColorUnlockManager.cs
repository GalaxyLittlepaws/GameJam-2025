using UnityEngine;

public class ColorUnlockManager : MonoBehaviour
{
    private static readonly int RedEnabled = Shader.PropertyToID("_RedEnabled");
    private static readonly int GreenEnabled = Shader.PropertyToID("_GreenEnabled");
    private static readonly int BlueEnabled = Shader.PropertyToID("_BlueEnabled");
    private static readonly int YellowEnabled = Shader.PropertyToID("_YellowEnabled");

    [SerializeField] private Material colorUnlockMaterial;

    private bool _isRedEnabled;
    private bool _isGreenEnabled;
    private bool _isBlueEnabled;
    private bool _isYellowEnabled;
    void Start() {
        _isRedEnabled = false;
        _isGreenEnabled = false;
        _isBlueEnabled = false;
        _isYellowEnabled = false;
        UpdateShader();
    }
    public void ToggleColor(string color, bool isEnabled)
    {
        switch (color.ToLower())
        {
            case "red":
                _isRedEnabled = isEnabled;
                Debug.Log("Red");
                break;
            case "green":
                _isGreenEnabled = isEnabled;
                Debug.Log("Green");
                break;
            case "blue":
                _isBlueEnabled = isEnabled;
                Debug.Log("Blue");
                break;
            case "yellow":
                _isYellowEnabled = isEnabled;
                Debug.Log("Yellow");
                break;
        }
        UpdateShader();
    }

    private void UpdateShader()
    {
        colorUnlockMaterial.SetFloat(RedEnabled, _isRedEnabled ? 1f : 0f);
        colorUnlockMaterial.SetFloat(GreenEnabled, _isGreenEnabled ? 1f : 0f);
        colorUnlockMaterial.SetFloat(BlueEnabled, _isBlueEnabled ? 1f : 0f);
        colorUnlockMaterial.SetFloat(YellowEnabled, _isYellowEnabled ? 1f : 0f);
    }
}