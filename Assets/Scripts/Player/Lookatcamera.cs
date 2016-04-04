using UnityEngine;
using System.Collections;

public class Lookatcamera : MonoBehaviour
{
    private Transform target;

    void Awake()
    {
        target = GameObject.Find("Camera").transform;
    }
    void Update()
    {
        transform.LookAt(target);
    }
}
