using UnityEngine;
using System.Collections;

public class KillPlayerOnTouch : MonoBehaviour
{
    SoundManager sound;
    PlayerMovement player;

    void Awake()
    {
        sound = GameObject.Find("Handeler").GetComponent<SoundManager>();
        player = GameObject.Find("Player(Goliath)").GetComponent<PlayerMovement>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            sound.PlayAudio(16, LoadMainMenu);
            player._anim.SetTrigger("Death");
            player.enabled = false;
        }
    }
    void LoadMainMenu()
    {
        HideMouse.UnlockCursor();
        Application.LoadLevel(0);
    }
}
