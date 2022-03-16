using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSails : IMovingState
{
    public IMovingState Move(BoatController contr, float sailPower)
    {
        return contr.changeState.ChangeState(this, contr);
    }
}
