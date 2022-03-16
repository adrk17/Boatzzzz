using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShape : MonoBehaviour, ICreateShape
{
    public static int xSize { get; set; } = 50;
    public static int zSize { get; set; } = 50;
    [SerializeField]
    private float xAmplitude = 1f;
    [SerializeField]
    private float zAmplitude = 1f;
    [SerializeField]
    private float xSpeed = 1f;
    [SerializeField]
    private float zSpeed = 1f;
    [SerializeField]
    private float zLenght = 1f;
    [SerializeField]
    private float xLenght = 1f;

    [SerializeField]
    private bool randomize = false;

    public int[] triangles { get; set; } = new int[xSize * zSize * 6];
    public Vector3[] vertices { get; set; } = new Vector3[(xSize + 1) * (zSize + 1)];
    public bool dynamic { get; set; } = true;

    public void CreateShape(int startX, int startZ, bool noTriangles)
    {
        for (int z = startZ, i = 0; z <= zSize + startZ; z++)
        {
            for (int x = startX; x <= xSize + startX; x++)
            {
                vertices[i] = new Vector3(x, yHeight(x, z, Time.time), z);
                i++;
            }
        }
        if (!noTriangles)
        {
            for (int z = 0, triPoints = 0, vertCounter = 0; z < zSize; z++, vertCounter++)
            {
                for (int x = 0; x < xSize; x++, vertCounter++)
                {
                    triangles[triPoints] = vertCounter;
                    triangles[triPoints + 1] = vertCounter + xSize + 1;
                    triangles[triPoints + 2] = vertCounter + 1;
                    triangles[triPoints + 3] = vertCounter + 1;
                    triangles[triPoints + 4] = vertCounter + xSize + 1;
                    triangles[triPoints + 5] = vertCounter + xSize + 2;
                    triPoints += 6;
                }
            }
        }
    }

    public float yHeight(int x, int z, float time)
    {
        float y = xAmplitude * Mathf.Sin(xLenght * x + time * xSpeed) + zAmplitude * Mathf.Sin(zLenght * z + time * zSpeed);// + 0.1f * Mathf.Sin(z + Time.time * 1f * zSpeed) + 0.1f * Mathf.Sin(x + Time.time * 1f * xSpeed);
        if (GetComponent<PerlinNoiseGenerator>() != null)
        {
            float perl = GetComponent<PerlinNoiseGenerator>().GenerateNoise(x, z, xSize, zSize);
            y = y * perl * perl;
        }
        return y;
    }
    private void Start()
    {
        if (randomize)
        {
            xSpeed = Random.Range(-2f, 2f);
            zSpeed = Random.Range(-2f, 2f);
            if (Mathf.Abs(xSpeed - zSpeed) < 1f) xSpeed += 1f;
            xAmplitude = Random.Range(0.1f, 0.7f);
            zAmplitude = Random.Range(0.1f, 0.7f);
            if (Mathf.Abs(xAmplitude - zAmplitude) < 0.3f) xAmplitude -= 0.3f;
            if (xAmplitude < 0.1f) xAmplitude = 0.1f;
            zLenght = Random.Range(0.4f, 1.5f);
            xLenght = Random.Range(0.4f, 1.5f);
        }
    }
}
