using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public Mesh mesh { get; set; }
    private float timer = 0f;
    public int startX { get; set; } = 0;
    public int startZ { get; set; } = 0;
    void Start()
    {
        mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        mesh.Clear();
        UpdateMesh(false);
    }

    private void FixedUpdate()
    {
        if (GetComponentInParent<ICreateShape>() != null && GetComponentInParent<ICreateShape>().dynamic)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= 0.05f)
            {
                UpdateMesh(true);
                timer = 0f;
            }
        }
    }
   

    void UpdateMesh(bool noTriangles)
    {
        if (gameObject.GetComponentInParent<ICreateShape>() == null)
        {
            print("returning");
            return;
        }
        gameObject.GetComponentInParent<ICreateShape>().CreateShape(startX, startZ, noTriangles);
        mesh.vertices = GetComponentInParent<ICreateShape>().vertices;
        if (!noTriangles)
        {
            mesh.triangles = GetComponentInParent<ICreateShape>().triangles;
        }
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
