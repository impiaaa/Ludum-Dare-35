using UnityEngine;
using System.Collections;

public class NoiseParticles : MonoBehaviour {
    ParticleSystem psys;
    ParticleSystem.Particle[] particles;

    void Start () {
        psys = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[psys.maxParticles];
    }

    void LateUpdate() {
        int numParticlesAlive = psys.GetParticles(particles);
        for (int i = 0; i < numParticlesAlive; i++) {
            Color c = particles[i].startColor;
            if (c.r == 0.0) {
                float gray = Random.value*Random.value;
                particles[i].startColor = new Color(gray, gray, gray, c.a);
            }
        }
        psys.SetParticles(particles, numParticlesAlive);
    }
}
