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
        removePerFrame = (int)Mathf.Abs(fps - minFPS)/5;
        //If target fps is not reached destroy the amound of objects needed
        if (fps < minFPS && brokenPeases.Count > removePerFrame) {
            for (int i = 0; i < removePerFrame; i++) { 
                Destroy(brokenPeases[i].gameObject);
                 brokenPeases.RemoveAt(i);
            }
        }
    }
}
