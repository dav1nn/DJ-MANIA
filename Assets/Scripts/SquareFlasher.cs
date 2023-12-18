using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareFlasher : MonoBehaviour
{
    public float flashDuration = 0.5f; 
    public Color[] colors; 

    private Renderer squareRenderer;
    private float timer;

    void Start()
    {
        squareRenderer = GetComponent<Renderer>();
        timer = flashDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            
            timer = flashDuration;

           
            Color randomColor = colors[Random.Range(0, colors.Length)];
            squareRenderer.material.color = randomColor;
        }
    }
}

