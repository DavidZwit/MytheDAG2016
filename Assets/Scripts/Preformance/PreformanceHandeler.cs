using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PreformanceHandeler : MonoBehaviour {

    [SerializeField]
    float fps;
    [SerializeField]
    int minFPS = 30, removePerFrame = 1;
    //List with broken peases
    List<GameObject> brokenPeases = new List<GameObject>();
    //Property to put things in the broken peases list
    public List<GameObject> BrokenPeases
    {
        get { return brokenPeases; }
        set { brokenPeases = value; }
    }

    void Update() {
        //Calculating the fps
        fps = (1.0f / Time.deltaTime);
        //Calculating how many to remove this frame
        removePerFrame = (int)Mathf.Clamp((minFPS - fps),0,50);
        //If target fps is not reached destroy the amound of objects needed
        if (fps < minFPS && brokenPeases.Count > removePerFrame) {
            for (int i = 0; i < removePerFrame; i++) {
                if (i < brokenPeases.Count) {
                    Destroy(brokenPeases[i].gameObject);
                    brokenPeases.RemoveAt(i);
                }
            }
        }
    }
}
