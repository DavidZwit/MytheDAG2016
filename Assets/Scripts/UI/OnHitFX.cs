using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnHitFX : MonoBehaviour
{

    [SerializeField]
    private RawImage fxImage;
    private float alphaFloat;
    private bool alphaDecrease;

    // Use this for initialization
    void Start()
    {
        fxImage = GetComponent<RawImage>();
        alphaDecrease = true;
        Color fxAlpha = fxImage.color;
        fxAlpha.a = 0;
        fxImage.color = fxAlpha;

    }

    void Update()
    {
        if (alphaDecrease)
        {
            Color fxAlpha = fxImage.color;
            //fxAlpha.a = alphaFloat;
            if (alphaFloat > 0)
            {
                fxAlpha.a = alphaFloat;
                alphaFloat -= 0.01f;
            }
            else
            {
                alphaDecrease = false;
            }
            fxImage.color = fxAlpha;
        }
    }

    public void TurnOn(float flashbang)
    {
        Color fxAlpha = fxImage.color;
        alphaFloat = 1f;
        fxAlpha.a = alphaFloat;
        fxImage.color = fxAlpha;
        //alphaFloat = 0.4f;
        alphaDecrease = true;
        //Invoke ("TurnOff", 0);
    }

    void TurnOff()
    {

        Color fxAlpha = fxImage.color;
        //fxAlpha.a = alphaFloat;
        while (alphaFloat > 0)
        {
            fxAlpha.a = alphaFloat;
            alphaFloat -= 0.01f;
        }
        fxImage.color = fxAlpha;
    }


}