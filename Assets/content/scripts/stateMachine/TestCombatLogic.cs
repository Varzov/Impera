using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatLogic : MonoBehaviour {

    int[] turnOrder;
    int turnCounter =-1;
    int turnMax=0;

    int roundCounter = 0;

    GameObject[] actorList;
    public GameObject selectedActor
    {
        get { return selectedActor; }
        set { selectedActor = gameObject; }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
