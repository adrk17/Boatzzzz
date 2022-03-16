using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovingState 
{
    IMovingState Move(BoatController contr, float sailPower);
}
