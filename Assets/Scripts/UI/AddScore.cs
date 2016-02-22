using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour
{
    private ScoreCount scoreCount;

    void Awake()
    {
        scoreCount = GameObject.Find("Score").GetComponent<ScoreCount>();
    }

    public void IncreaseScore()
    {
        scoreCount._ScoreCounter += 100;
    }
}
