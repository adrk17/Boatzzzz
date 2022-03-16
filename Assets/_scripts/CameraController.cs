using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField]
    private Transform followObj;
    [SerializeField]
    private float transitionSpeed = 15f;
    [SerializeField]
    private Vector3 offset;
    private void RotateCamera()
    {
        
        Vector3 lookDir = followObj.position - cameraTransform.position + new Vector3(0f, 1f, 0f);
        Quaternion rotation;
        rotation = Quaternion.LookRotation(lookDir, Vector3.up);
        cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, rotation, transitionSpeed * Time.fixedDeltaTime);
         
    }

    private void MoveCamera()
    {
        Vector3 target = followObj.position + followObj.forward * offset.z + followObj.right * offset.x + followObj.up * offset.y;
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, target, transitionSpeed * Time.fixedDeltaTime);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = gameObject.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateCamera();
        MoveCamera();
    }
}
