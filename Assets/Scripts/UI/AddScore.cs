using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour
{
    private ScoreCount scoreCount;

    void Start()
    {
        scoreCount = GameObject.Find("Score").GetComponent<ScoreCount>();
    }

    public void IncreaseScore()
    {
        scoreCount.ScoreCounter += 100;
    }
}
