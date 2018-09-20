using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    [SerializeField] GameObject[] mainTurrets;
    [SerializeField] GameObject[] mainWeapons;

    public bool hasMoved { get; set; }
    public bool isMoving { get; set; }
    public bool hasFired { get; set; }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
