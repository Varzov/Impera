using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitBattleState : CombatState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine(InitializeCombat());
    }

    IEnumerator InitializeCombat()
    {
        combatControllerParent.PopulateUnitList();
        combatControllerParent.CalculateInitiative();
        combatControllerParent.selectedUnit = combatControllerParent.initiativeList[0];
        combatControllerParent.currentUnitIndex = 0;
        print("unit with highest initiative is" + combatControllerParent.initiativeList[0]);
        yield return null;
        combatControllerParent.ChangeState<UnitSelectedState>();
    }
}