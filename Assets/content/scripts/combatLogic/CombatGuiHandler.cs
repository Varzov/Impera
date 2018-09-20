using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatGuiHandler : MonoBehaviour {

    [SerializeField] Texture2D moveCursor = null;
    [SerializeField] Texture2D noMoveCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);
    

    // Use this for initialization
    void Start ()
    {
        cursorHotspot = new Vector2(moveCursor.width / 2, moveCursor.height / 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCursor(string cursor)
    {
        switch (cursor)
        {
            case "moveYes":
                Cursor.SetCursor(moveCursor, cursorHotspot, CursorMode.Auto);
                break;
            case "moveNo":
                  Cursor.SetCursor(noMoveCursor, cursorHotspot, CursorMode.Auto);
                  break;  
            default:
            break;
        }
    }



}
