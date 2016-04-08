using UnityEngine;
using System.Collections;

public class HideMouse : MonoBehaviour {

    //Lock Cursor and visablility is false
	void Awake ()
    {
        LockCursor();
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
