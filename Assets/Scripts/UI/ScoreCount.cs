using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private float scoreCounter;
    public float ScoreCounter
    {
        get { return scoreCounter; }
        set { scoreCounter = value; }
    }

    void Update()
    {
        scoreText.text = "Score: " + scoreCounter;
    }
}