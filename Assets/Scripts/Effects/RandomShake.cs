using UnityEngine;
using System.Collections;

public class RandomShake : MonoBehaviour {
    Vector2 boundries;
    Vector3 beginPos;
    bool reset, shaking;
    float time, rate;

    public void Shake(Vector2 boundries, float time, float rate)
    {
        if (!shaking) {
            //Setting the parameters to varuables
            this.boundries = boundries;
            this.time = time; this.rate = rate;
            shaking = true;
            beginPos = transform.localPosition;
            //Starting the loop
            InvokeRepeating("ApplyShake", 0, rate);
        }
    }

    void ApplyShake()
    {
        //Toggeling from a random position to the origin position
        if (!reset)
            transform.localPosition = new Vector3(transform.localPosition.x + Random.Range(boundries.x, -boundries.x),
                transform.localPosition.y + Random.Range(boundries.y, -boundries.y),
                transform.localPosition.z);
        else { transform.localPosition = beginPos; }
        reset = !reset;
        //If time is over stop the loop
        time -= rate;
        if (time < 0) {
            transform.localPosition = beginPos; shaking = false;
            CancelInvoke("ApplyShake");
        }
    }
}
