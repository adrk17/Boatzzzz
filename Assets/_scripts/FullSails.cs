using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSails : IMovingState
{
    public IMovingState Move(BoatController contr, float sailPower)
    {
        contr.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(sailPower, 0f, 0f), ForceMode.Acceleration);
        return contr.changeState.ChangeState(this, contr);
    }
}
