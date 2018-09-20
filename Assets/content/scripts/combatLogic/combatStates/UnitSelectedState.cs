using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedState : CombatState {

    public override void Enter()
    {

        base.Enter();
    }

 

    protected override void AddListeners()
    {
        base.AddListeners();
        combatInputController.MoveOrderDelegate += onMoveOrder;
        combatInputController.EndUnitPhaseDelegate += onEndPhase;

    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        combatInputController.MoveOrderDelegate -= onMoveOrder;
        combatInputController.EndUnitPhaseDelegate -= onEndPhase;
    }

    private void onEndPhase()
    {
        combatControllerParent.ChangeState<SelectNextUnit>();
    }

    private void onMoveOrder()
    {
        combatControllerParent.ChangeState<MoveUnitState>();
    }
}
