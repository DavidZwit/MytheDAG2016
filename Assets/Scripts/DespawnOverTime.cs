using UnityEngine;
using System.Collections;

public class DespawnOverTime : MonoBehaviour
{
    [SerializeField]
    float delay;
    [SerializeField]
    float lifetime = 5;
    float startTime;

    Renderer color;

    void Start()
    {
        startTime = lifetime;
        lifetime = (lifetime) + (delay);
        color = GetComponent<Renderer>();
        color.material.color = new Color(1, 1, 1, 1);
    }

    void FixedUpdate() {
        lifetime-=0.1f;

        if (lifetime/startTime < 1)
            color.material.color = new Color(1, 1, 1, lifetime/startTime);

        if (lifetime < 0) {
             Destroy(gameObject);
        }
    }
}
