using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    public int floaterCount { get; set; } = 1;

    private float waveHeight;

    [SerializeField]
    private float depthBeforeSubmerged = 1f;
    [SerializeField]
    private float displacementAmount = 3f;
    [SerializeField]
    private float waterDrag = 0.99f;
    [SerializeField]
    private float waterAngularDrag = 1f;


    void FixedUpdate()
    {
        waveHeight = GetComponentInParent<NearestPointToMesh>().FindNearestPoint(transform.position).y; 
        float posY = transform.position.y;

        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);
        if (posY < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - posY) / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
