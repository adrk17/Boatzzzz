using UnityEngine;
public interface ICreateShape
{
    public int[] triangles { get; set; }
    public Vector3[] vertices { get; set; }
    public bool dynamic { get; set; }

    //Returning if the shape is dynamic or not
    void CreateShape(int startX, int startZ, bool noTriangles);
}
