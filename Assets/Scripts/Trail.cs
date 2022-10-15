using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Vector3 direction { get; private set; }
    public TrailRenderer trailRenderer;

    Camera mainCamera;
    bool trailEnabled;

    void Start()
    {
        mainCamera = Camera.main;
        ChangeTrailColor();
    }

    void OnEnable()
    {
        StopTrail();
    }

    void OnDisable()
    {
        StopTrail();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartTrail();
        }

        else if(Input.GetMouseButtonUp(0))
        {
            StopTrail();
        }

        else if(trailEnabled)
        {
            ContinueTrail();
        }
    }

    void StartTrail()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        transform.position = newPosition;
        trailEnabled = true;
        trailRenderer.enabled = true;
        trailRenderer.Clear();
    }

    void StopTrail()
    {
        trailEnabled = false;
        trailRenderer.enabled = false;
    }

    void ContinueTrail()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        transform.position = newPosition;
    }

    public void ChangeTrailColor()
    {
        float darknessAmount = 1.3f;
        trailRenderer.startColor = mainCamera.backgroundColor * darknessAmount;
        trailRenderer.endColor = mainCamera.backgroundColor * darknessAmount;
    }
}
