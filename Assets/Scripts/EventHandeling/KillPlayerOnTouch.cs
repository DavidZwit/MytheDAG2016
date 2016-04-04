using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
            Application.LoadLevel(0);
    }
}
