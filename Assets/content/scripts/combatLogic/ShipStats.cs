using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour {

    [SerializeField] private int defaultInitiave = 8;
    private int Initiative;
    public int currentInitiative;

	// Use this for initialization
	void Start ()
    {
        Initiative = defaultInitiave;
        currentInitiative = Initiative;
	}

    public int GetInitiative ()
    {
        return currentInitiative;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
