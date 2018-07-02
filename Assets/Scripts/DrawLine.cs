using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] GameObject player;

    // Use this for initialization
    void Start()
    {
        InitializeLineRenderer();
    }

    void InitializeLineRenderer() {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

        lineRenderer.startColor = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPosition(0, player.transform.position);
        lineRenderer.SetPosition(1, player.GetComponent<PlayerController>().hit.point);
    }
}