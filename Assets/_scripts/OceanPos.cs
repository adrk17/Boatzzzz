using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanPos : MonoBehaviour
{
    [SerializeField]
    private Transform boat;
    [SerializeField]
    private float transitionSpeed = 1f;
    private bool lerping = false;

    // Update is called once per frame
    void  FixedUpdate()
    {
        if (lerping || boat.position.x > transform.position.x + 90f || boat.position.x < transform.position.x + 10f || boat.position.z > transform.position.z + 90f || boat.position.z < transform.position.z + 10f)
        {
            
            lerping = true;
            Vector3 target = new Vector3(boat.position.x-50f, 0f, boat.position.z- 50f); 
            transform.position = Vector3.Lerp(transform.position, target, transitionSpeed * Time.fixedDeltaTime);
            if ((target - transform.position).sqrMagnitude < 75f) 
            {
                lerping = false;
            }
        } 
    }
}
