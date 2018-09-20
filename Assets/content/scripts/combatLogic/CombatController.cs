using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : StateMachine
{
    public Camera mainCamera;
    public MainCameraRaycast mainCameraRaycast { get { return mainCamera.GetComponent<MainCameraRaycast>(); } }
    public CombatGuiHandler combatGuiHandler;

    public ShipMovementLogic shipMoveLogic;
    public CombatInputController combatInputController;

    public GameObject selectedUnit;
    public List<GameObject> initiativeList = new List<GameObject>();
    public int currentUnitIndex;
    public bool isPlayerTurn = true;


    void Start()
    {
        shipMoveLogic = GetComponent<ShipMovementLogic>();
        combatGuiHandler = GetComponent<CombatGuiHandler>();
        combatInputController = GetComponent<CombatInputController>();
        mainCamera = Camera.main;
        ChangeState<InitBattleState>();
    }

    public void PopulateUnitList()
    {
        GameObject[] unitsOnField = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject foundUnit in unitsOnField)
        {
            initiativeList.Add(foundUnit);
        }
    }

    public void CalculateInitiative()
    {
        initiativeList.Sort((a, b) => b.GetComponent<ShipStats>().GetInitiative().CompareTo(a.GetComponent<ShipStats>().GetInitiative()));
    }

    public void SetSelectedUnit(GameObject unit)
    {
        if (selectedUnit == unit)
        {
            return;
        }

        else
        {
            selectedUnit = unit;

        }
    }

}
