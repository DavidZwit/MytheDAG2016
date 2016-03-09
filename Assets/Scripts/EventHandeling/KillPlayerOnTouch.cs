using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillPlayerOnTouch : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
			SceneManager.LoadScene(0);
    }
}
