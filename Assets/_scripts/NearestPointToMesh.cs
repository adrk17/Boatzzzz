using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestPointToMesh : MonoBehaviour
{
   [SerializeField]
   private GameObject meshObj;

   public Vector3 FindNearestPoint(Vector3 point)
   {
        Vector3 nearestPoint = Vector3.zero;
        foreach(Vector3 v in meshObj.GetComponent<MeshGenerator>().mesh.vertices)
        {
            if((point - v).sqrMagnitude < (point - nearestPoint).sqrMagnitude)
            {
                nearestPoint = v;
            }
        }
        return nearestPoint;
   }
}
