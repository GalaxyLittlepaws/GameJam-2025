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

    public void ToggleColor(string color, bool isEnabled)
    {
        switch (color.ToLower())
        {
            case "red":
                _isRedEnabled = isEnabled;
                break;
            case "green":
                _isGreenEnabled = isEnabled;
                break;
            case "blue":
                _isBlueEnabled = isEnabled;
                break;
            case "yellow":
                _isYellowEnabled = isEnabled;
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