using UnityEngine;

public class ColorUnlockManager : MonoBehaviour
{
    private static readonly int RedProgress = Shader.PropertyToID("_RedProgress");
    private static readonly int GreenProgress = Shader.PropertyToID("_GreenProgress");
    private static readonly int BlueProgress = Shader.PropertyToID("_BlueProgress");
    [SerializeField] private Material colorUnlockMaterial;
    private float _redProgress;
    private float _greenProgress;
    private float _blueProgress;

    public void UnlockColor(string color)
    {
        switch (color.ToLower())
        {
            case "red":
                _redProgress = 1f;
                break;
            case "green":
                _greenProgress = 1f;
                break;
            case "blue":
                _blueProgress = 1f;
                break;
        }

        UpdateShader();
    }

    private void UpdateShader()
    {
        colorUnlockMaterial.SetFloat(RedProgress, _redProgress);
        colorUnlockMaterial.SetFloat(GreenProgress, _greenProgress);
        colorUnlockMaterial.SetFloat(BlueProgress, _blueProgress);
    }
}