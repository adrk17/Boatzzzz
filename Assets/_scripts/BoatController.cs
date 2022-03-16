using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    [SerializeField]
    private float sailPower = 300f;
    [SerializeField]
    private float maneuverability  = 20f;

    private IMovingState currentState;
    public NoSails idleState { get; set; } = new NoSails();
    public HalfSails halfSailState { get; set; } = new HalfSails();
    public FullSails fullSailsState { get; set; } = new FullSails();
    public ChangeMovingState changeState { get; set; } = new ChangeMovingState();
    private TurningManager turningManager = new TurningManager();

    float timer = 0f;
    
    void Start()
    {
        currentState = idleState;
        print(currentState.GetType());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
   
       currentState = currentState.Move(this, sailPower);
       turningManager.Turn(this, currentState, maneuverability);
    
    }
}
