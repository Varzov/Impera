using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnitState : CombatState

{
    public int walkableLayerNumber = 8;
    public float maxRaycastDepth = 900;

    CombatController combatController;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }


    public override void Enter()
    {
        base.Enter();
        StartCoroutine(InitializeMoveState());
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        combatInputController.MoveOrderDelegate += onMoveOrder;
        combatInputController.ReturnDefaultStateDelegate += onSetDefaultState;
        combatInputController.EndUnitPhaseDelegate += onEndPhase;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        combatInputController.MoveOrderDelegate -= onMoveOrder;
        combatInputController.ReturnDefaultStateDelegate -= onSetDefaultState;
        combatInputController.EndUnitPhaseDelegate -= onEndPhase;
    }

    private void onEndPhase()
    {
        shipMoveLogic.currentShip = null;
    }

    private void onSetDefaultState()
    {
        //StartCoroutine(deInitializeMoveState());
        shipMoveLogic.currentShip = null;
        print("onSetDefaultState is called");
        combatControllerParent.ChangeState<UnitSelectedState>();
    }

    private void onMoveOrder()
    {

    }


    private void Update()
    {
        SetDestination(); 
    }

    private void GetDestinationInput()
    {
        //if (isPlayerTurn)
       // {
            //destinationCache = mainCameraRaycast.cursorPoint;
       // }
    }

    private void SetDestination()
    {
        //Try to figure out how to make this generalized enough for player and AI
        //probably will be done via getDestination
        var hit = mainCameraRaycast.RaycastForDestination();

        Vector3 clickDirection = hit - currentUnit.transform.position;
        Vector3 heading = currentUnit.transform.forward;
        float angle = Vector3.Angle(clickDirection, heading);
        var dist = Vector3.Distance(hit, currentUnit.transform.position);

        if (angle < 90.0F && dist < 120f)
        {
            combatGuiHandler.SetCursor("moveYes");
            shipMoveLogic.OnMoveOrderInput(hit);
        }

        else
        {
            combatGuiHandler.SetCursor("moveNo");
        }
    }

    IEnumerator InitializeMoveState()
    {
        shipMoveLogic.currentShip = combatControllerParent.selectedUnit;
        print("Starting Movement Phase");
        yield return null;
    }

    IEnumerator deInitializeMoveState()
    {
        shipMoveLogic.currentShip = null;
        yield return null;
        combatControllerParent.ChangeState<UnitSelectedState>();
     
    }


}