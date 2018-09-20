using UnityEngine;
using System.Collections;
using System;

public abstract class CombatState : State
{
    protected CombatController combatControllerParent;
    public GameObject currentUnit { get { return combatControllerParent.selectedUnit; }}
    public Camera mainCamera { get { return combatControllerParent.mainCamera; } }
    public MainCameraRaycast mainCameraRaycast { get { return combatControllerParent.mainCameraRaycast; } }
    public ShipMovementLogic shipMoveLogic { get { return combatControllerParent.shipMoveLogic; } }
    public CombatInputController combatInputController { get { return combatControllerParent.combatInputController; } }
    public CombatGuiHandler combatGuiHandler { get { return combatControllerParent.combatGuiHandler; } }
    public bool isPlayerTurn { get { return combatControllerParent.isPlayerTurn; } }

    protected virtual void Awake()
    {
        combatControllerParent = GetComponent<CombatController>();
    }

    protected override void AddListeners()
    {
 
    }

    protected override void RemoveListeners()
    {

    }

    protected virtual void onMoveOrderInput(Vector3 destination)
    {

    }

}