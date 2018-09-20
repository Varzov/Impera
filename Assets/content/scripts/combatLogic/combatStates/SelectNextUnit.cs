using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNextUnit : CombatState {

	// Use this for initialization
    

    public override void Enter()
    {
        base.Enter();

        if (combatControllerParent.currentUnitIndex == (combatControllerParent.initiativeList.Count-1))
        {
            StartCoroutine(BeginEndTurnSequence());
            print("selected unit count equals list length, ending turn");    
        }
        else
        {
            StartCoroutine(SelectNextUnitInQue());
            print("Selecting next unit");
            print(combatControllerParent.initiativeList.Count);
        } 
    }

    IEnumerator BeginEndTurnSequence()
    {
        combatControllerParent.currentUnitIndex = 0;
        combatControllerParent.selectedUnit = combatControllerParent.initiativeList[0];
        yield return null;
        combatControllerParent.ChangeState<UnitSelectedState>();
    }

    IEnumerator SelectNextUnitInQue()
    {
        combatControllerParent.currentUnitIndex++;
        combatControllerParent.selectedUnit = combatControllerParent.initiativeList[combatControllerParent.currentUnitIndex];
        print(combatControllerParent.selectedUnit.name);
        yield return null;
        combatControllerParent.ChangeState<UnitSelectedState>();
    }

}
