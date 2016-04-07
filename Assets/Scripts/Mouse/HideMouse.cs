using UnityEngine;
using System.Collections;

public class HideMouse : MonoBehaviour {

    //Lock Cursor and visablility is false
	void Awake ()
    {
        LockCursor();
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
