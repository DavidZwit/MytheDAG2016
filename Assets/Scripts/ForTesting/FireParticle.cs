using UnityEngine;
using System.Collections;

public class FireParticle : MonoBehaviour
{
    private RampageBar rageOrNaw;
    private SoundManager sound;

    // Use this for initialization
    void Awake ()
    {
        rageOrNaw = GameObject.Find("RampageBar").GetComponent<RampageBar>();
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        sound = GameObject.Find("Handeler").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rageOrNaw.enraged == true)
        {
            if (Input.GetButton("Fire2"))
            {
                gameObject.GetComponent<ParticleSystem>().enableEmission = true;
                sound.PlayAudioIfNotPlaying(21);
            }
            else
            {
                gameObject.GetComponent<ParticleSystem>().enableEmission = false;
            }
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}
