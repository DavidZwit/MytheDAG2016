using UnityEngine;
using System.Collections;

public class FireParticle : MonoBehaviour
{
    private RampageBar rageOrNaw;

    // Use this for initialization
    void Awake ()
    {
        rageOrNaw = GameObject.Find("RampageBar").GetComponent<RampageBar>();
        gameObject.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rageOrNaw.enraged == true)
        {
            if (Input.GetButton("Fire2"))
            {
                gameObject.GetComponent<ParticleSystem>().enableEmission = true;
            }
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
        }
        
    }
}
