using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnState : CombatState {

    public override void Enter()
    {
        base.Enter();
        print("oh fuck, ending turn");
    }

    
}
