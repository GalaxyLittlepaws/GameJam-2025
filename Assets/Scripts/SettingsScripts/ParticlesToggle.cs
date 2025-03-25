using UnityEngine;

public class ParticlesToggle : MonoBehaviour {

    [SerializeField] bool important = true;
    AccessibilityManager manager;
    ParticleSystem particle;

    void Start() {
        manager = FindObjectOfType<AccessibilityManager>();
        particle = GetComponent<ParticleSystem>();
    }

    void Update() {
        ParticleSystem.EmissionModule em = particle.emission;
        if (manager.particles == 0) {
            em.enabled = true;
        } else if (manager.particles == 1) {
            if (important) {
                em.enabled = true;
            } else {
                em.enabled = false;
            }
        } else if (manager.particles == 2) {
            em.enabled = false;
        }
    }
}
