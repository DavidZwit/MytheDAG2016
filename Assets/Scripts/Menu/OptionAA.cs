using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionAA : MonoBehaviour
{
    public Slider sliderAA;
    [SerializeField]
    private Text sliderText;

    void Update()
    {
        //Set AA off
        if (sliderAA.value == 0)
        {
            QualitySettings.antiAliasing = 0;
            sliderText.text = "Anti Aliasing: Off";
        }

        //Set AA x2
        else if (sliderAA.value == 1)
        {
            QualitySettings.antiAliasing = 2;
            sliderText.text = "Anti Aliasing: 2x";
        }

        //Set AA x4
        else if (sliderAA.value == 2)
        {
            QualitySettings.antiAliasing = 4;
            sliderText.text = "Anti Aliasing: 4x";
        }

        //Set AA x8
        else if (sliderAA.value == 3)
        {
            QualitySettings.antiAliasing = 8;
            sliderText.text = "Anti Aliasing: 8x";
        }
    }
}