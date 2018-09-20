using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatInputController : MonoBehaviour {

    CombatController combatController;
    public GameObject selectedUnit { get { return combatController.selectedUnit; } }
    private Camera cam { get { return combatController.mainCamera; } }


    [SerializeField] Texture2D moveCursor = null;
    [SerializeField] Texture2D noMoveCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

    public delegate void OnButtonClickDelegate();
    public static OnButtonClickDelegate buttonClickDelegate;
    public bool isInMoveMode = false;

    public void OnButtonClick()
    {
        buttonClickDelegate();
    }

    public delegate void OnMoveOrder();
    public event OnMoveOrder MoveOrderDelegate;

    public delegate void OnReturnToDefaultState();
    public event OnReturnToDefaultState ReturnDefaultStateDelegate;

    public delegate void OnEndUnitPhase();
    public event OnEndUnitPhase EndUnitPhaseDelegate;

    void Start ()
    {
        combatController = GetComponent<CombatController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Move") && !isInMoveMode)
        {
            isInMoveMode = !isInMoveMode;
            MoveOrderDelegate();
        }
        else if (Input.GetButtonDown("Move") && isInMoveMode)
        {
            print("Ending Movement Phase");
            isInMoveMode = !isInMoveMode;
            ReturnDefaultStateDelegate();
        }
        if (Input.GetButtonDown("EndTurn"))
        {
            isInMoveMode = false;
            EndUnitPhaseDelegate();
            print("endingcurrentUnitPhase");
        }
    }

}
