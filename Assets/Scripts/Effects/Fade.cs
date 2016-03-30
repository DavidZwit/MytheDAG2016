using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour
{
    public delegate void FadeEnded();
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFade(float time, FadeEnded fadeEnded)
    {
        float alpha = image.color.a;
        print(alpha);
        if (alpha > 0)
            StartCoroutine(Fader(time, true, fadeEnded));
        else
            StartCoroutine(Fader(time, false, fadeEnded));
    }

    IEnumerator Fader(float time, bool fadeSwitch, FadeEnded fadeEnded)
    {
        Color a;
        while (time >= 0)
        {
            a = image.color;

            if (fadeSwitch)
                a.a -= ((1 / time) / 100);
            else
                a.a += ((1 / time) / 100);

            image.color = a;

            time -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        a = image.color;

        if (fadeSwitch)
            a.a = 0;
        else a.a = 1;

        image.color = a;
        fadeEnded();
        yield return null;
    }
}
