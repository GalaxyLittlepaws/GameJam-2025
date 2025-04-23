using System.Collections.Generic;
using UnityEngine;

public class ShaderManager : MonoBehaviour {
    [SerializeField] List<SpriteRenderer> sprites;
    [SerializeField] Material colorShader;
    [SerializeField] Material normal;

    public void NormalColour() {
        foreach (SpriteRenderer e in sprites) {
            e.material = normal;
        }
    }
}
