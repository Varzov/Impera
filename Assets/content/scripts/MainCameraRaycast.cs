using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRaycast : MonoBehaviour {

    public int walkableLayerNumber = 8;
    public float maxRaycastDepth = 900;

    CombatController combatController;
    private Camera cam;

    Vector3 mouseposition;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
 
    }

    public Vector3 RaycastForDestination()
    {
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask walkableLayer = 1 << walkableLayerNumber;
            Physics.Raycast(ray, out hit, maxRaycastDepth, walkableLayer);
            mouseposition = hit.point;
            return hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(mouseposition, 0.2f);
    }

    /*private bool RaycastForWalkable(Ray ray)
    {
        RaycastHit hitInfo;
        LayerMask walkableLayer = 1 << walkableLayerNumber;
        bool walkableHit = Physics.Raycast(ray, out hitInfo, maxRaycastDepth, walkableLayer);
        if (walkableHit)
        {
            onMouseOverTerrain(hitInfo.point);
            return true;
        }
        return false;
    }
    */
}
