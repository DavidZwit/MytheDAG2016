using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour
{
    private ScoreCount scoreCount;

    void Awake()
    {
        scoreCount = GameObject.Find("Score").GetComponent<ScoreCount>();
    }
   
    public void IncreaseScore(int score)
    {
        //Can be called to add score
        scoreCount._ScoreCounter += score;
    }

    public void DecreaseScore(int score)
    {
        //Can be called to remove score
        scoreCount._ScoreCounter -= score;
    }
}
