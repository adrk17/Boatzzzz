using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseGenerator : MonoBehaviour
{
    [SerializeField]
    private float scale = 1f;
    [SerializeField]
    private float zOffset = 0f;
    [SerializeField]
    private float xOffset = 0f;
    [SerializeField]
    private bool randomize = false;
    public float GenerateNoise(int x, int z, int lenght, int width)
    {
        float xCor = (float)x / lenght * scale + xOffset;
        float zCor = (float)z / width * scale + zOffset;
        float perl = Mathf.PerlinNoise(xCor, zCor);
        return perl;
    }

    private void Start()
    {
        if (randomize)
        {
            scale = Random.Range(50f, 150f);
            xOffset = Random.Range(0f, 99999f);
            zOffset = Random.Range(0f, 99999f);
        }
    }
}
