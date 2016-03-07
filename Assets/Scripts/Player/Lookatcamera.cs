using UnityEngine;
using System.Collections;

public class Lookatcamera : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.LookAt(target);
    }
}
