using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float scoreCounter;
    public float _ScoreCounter
    {
        get { return scoreCounter; }
        set { scoreCounter = value; }
    }

    void Update()
    {
        //Setting the score
        scoreText.text = "Score: " + scoreCounter;
    }
}