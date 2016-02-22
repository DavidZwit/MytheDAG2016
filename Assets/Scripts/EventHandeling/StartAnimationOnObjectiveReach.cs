using UnityEngine;
using System.Collections;

public class StartAnimationOnObjectiveReach : MonoBehaviour {

	void OnEnable()
    {
        EventHandeler._ObjectiveReached += PlayAnimation;
    }

    void OnDisable()
    {
        EventHandeler._ObjectiveReached -= PlayAnimation;
    }

    void PlayAnimation()
    {
        GetComponent<Animator>().SetTrigger("ObjectiveReached");
    }
}
