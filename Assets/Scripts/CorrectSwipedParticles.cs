using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectSwipedParticles : MonoBehaviour
{
    public Camera mainCamera;

    ParticleSystem particle;

    void Start()
    {
        mainCamera = Camera.main;
        ParticleSystem.MainModule mainModule = GetComponent<ParticleSystem>().main;
        float darknessAmount = 1.55f;
        mainModule.startColor = mainCamera.backgroundColor * darknessAmount;
    }
}
