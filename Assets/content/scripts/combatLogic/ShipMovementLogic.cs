using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipMovementLogic : MonoBehaviour {

    private CombatController combatControllerParent;
    private CombatInputController inputController;

    [SerializeField] Vector3[] movePath = new Vector3[6];
    private float maxMoveAngle = 90f; //if hardcode this value, it's a-okay, but we can't hardcode it actually, because that's actual ship move range
    public GameObject currentShip;
    public Collider shapeCollider;

    private bool isMovementAnimationPlaying = false;

    void Start ()
    {
        combatControllerParent = GetComponent<CombatController>();
        InitVisualDebugVector();
        inputController = GetComponent<CombatInputController>();
    }

    private void setupCurrentShipVariables()
    {

    }

    private void InitVisualDebugVector()
    {
        movePath = new Vector3[6];
        movePath[0] = new Vector3(0.0f, 0.0f, 0.0f);
        movePath[0] = new Vector3(0.0f, 0.0f, 0.0f);
        movePath[1] = new Vector3(0.0f, 0.0f, 0.0f);
        movePath[2] = new Vector3(0.0f, 0.0f, 0.0f);
        movePath[3] = new Vector3(0.0f, 0.0f, 0.0f);
        movePath[4] = new Vector3(0.0f, 0.0f, 0.0f);
    }
    

    public void OnMoveOrderInput(Vector3 destination)
    {
        if (currentShip && isMovementAnimationPlaying != true)
        {
            CalculateTrajectory(destination);
            if (Input.GetMouseButton(0))
            {
                isMovementAnimationPlaying = !isMovementAnimationPlaying;
                MoveToPoint(destination);
            }
        }
    }
     
    public void MoveToPoint(Vector3 destination)
    {

        int timeToTarget = 7;
        iTween.MoveTo(currentShip, iTween.Hash(
            "path", CalculateTrajectory(destination), "time", timeToTarget, "orienttopath", true, "looktime", 3f, 
            "delay", 0.1f, "easetype", "easeInOutSine", "oncomplete", "resetMoveStatus", "oncompletetarget", gameObject));
    }
    

    private void resetMoveStatus()
    {
        print("ResetMoveStatusLaunching");
        isMovementAnimationPlaying = false;
    }
 
    public Vector3[] CalculateTrajectory (Vector3 destination)
    {
        //cavemen coding intensifies
        //Grog Not Code Good
        Vector3 currentPosition = currentShip.transform.position;
        Vector3 forwardVector = currentShip.transform.forward;
        Vector3 directPath = destination - currentPosition;

        float angle = Vector3.Angle(destination, currentShip.transform.forward);
        float destinationMagnitude = (destination - currentShip.transform.position).magnitude * 0.1f;
        float scaledValue = angle / maxMoveAngle;
       //float angleCoefficient = Mathf.Lerp(1.5f, 6f, scaledValue);

        Vector3 curvePointPosition = forwardVector * destinationMagnitude;
        
        Vector3[] moveTrajectory = new Vector3[6];
        moveTrajectory[0] = currentPosition;
        moveTrajectory[1] = currentPosition + (forwardVector * destinationMagnitude)*2f;
        moveTrajectory[2] = (directPath * Mathf.Lerp(0.045f, 0.08f, scaledValue)) + ((currentPosition + curvePointPosition * Mathf.Lerp(0.51f, 2.2f, scaledValue))) + (moveTrajectory[1] - currentPosition);
        moveTrajectory[3] = (directPath * Mathf.Lerp(0.2f, 0.28f, scaledValue)) + ((currentPosition +  curvePointPosition * Mathf.Lerp(0.8f, 3.2f, scaledValue)))  + (moveTrajectory[1] - currentPosition);
        moveTrajectory[4] = (directPath * Mathf.Lerp(0.45f, 0.55f, scaledValue)) + ((currentPosition +  curvePointPosition * Mathf.Lerp(0.5f, 2f, scaledValue))) + (moveTrajectory[1] - currentPosition);
        moveTrajectory[5] = destination;
        movePath = moveTrajectory;
        return moveTrajectory; 
    }

    void Update () {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(movePath[1], 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(movePath[2], 0.5f);
        Gizmos.DrawSphere(movePath[3], 0.5f);
        Gizmos.DrawSphere(movePath[4], 0.5f);
        Gizmos.DrawSphere(movePath[5], 0.5f);
        iTween.DrawPath(movePath);
    }

}
