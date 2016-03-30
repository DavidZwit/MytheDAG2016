using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverCountdown : MonoBehaviour
{
    private Text countDown;
    [SerializeField] private float time = 15;

    void Awake()
    {
        countDown = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        time -= Time.deltaTime;

        float sec = time % 60;
        countDown.text = string.Format("{0:0}", sec);

        if (time <= 0)
            StartCoroutine(TimeUp());
    }

    IEnumerator TimeUp()
    {
        time = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
