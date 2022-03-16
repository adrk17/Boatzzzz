using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningManager 
{
    public void Turn(BoatController boat, IMovingState currentState, float maneuverability)
    {
        float stateModifier;
        if(currentState.GetType() == typeof(HalfSails))
        {
            stateModifier = 6f;
        }
        else if(currentState.GetType() == typeof(FullSails))
        {
            stateModifier = 3f;
        }
        else
        {
            stateModifier = 1f;
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            boat.gameObject.transform.Rotate(new Vector3(0f,Time.fixedDeltaTime * Input.GetAxis("Horizontal") * stateModifier * maneuverability, 0f));
        }
    }
}
