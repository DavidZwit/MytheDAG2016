using UnityEngine;
using System.Collections;

public class RandomShake : MonoBehaviour {
    Vector2 boundries, beginPos;
    bool reset;
    float time, rate;

    public void Shake(Vector2 boundries, float time, float rate)
    {
        this.boundries = boundries;
        this.time = time;
        this.rate = rate;
        beginPos = transform.localPosition;

        InvokeRepeating("ApplyShake", time, rate);
    }

    void ApplyShake()
    {
        if (!reset)
            transform.localPosition = new Vector2(transform.localPosition.x + Random.Range(boundries.x, -boundries.x),
                transform.localPosition.y + Random.Range(boundries.y, -boundries.y));
        else transform.localPosition = beginPos;
        reset = !reset;

        time -= rate;
        if (time < 0) {
            transform.localPosition = beginPos;
            CancelInvoke("ApplyShake");
        }
    }
}
