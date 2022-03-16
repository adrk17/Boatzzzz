using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMovingState 
{
    private bool canChange = true;
    public IMovingState ChangeState(IMovingState prevState, BoatController contr)
    {
        if (Input.GetAxis("Vertical") == 0) canChange = true;
        if (canChange)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                if (prevState.GetType() == typeof(NoSails))
                {
                    canChange = false;
                    return contr.halfSailState;
                }
                else if (prevState.GetType() == typeof(HalfSails))
                {
                    canChange = false;
                    return contr.fullSailsState;
                }
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                if (prevState.GetType() == typeof(HalfSails))
                {
                    canChange = false;
                    return contr.idleState;
                }
                else if (prevState.GetType() == typeof(FullSails))
                {
                    canChange = false;
                    return contr.halfSailState;
                }
            }
        }
        return prevState;
    }
}
