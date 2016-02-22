using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionAA : MonoBehaviour
{
    [SerializeField] private Slider sliderAA;
    [SerializeField] private Text sliderText;
    private float sliderValue;

    void Update()
    {
        sliderValue = sliderAA.value;
        

        //Set AA off
        if (sliderValue == 0)
        {
            QualitySettings.antiAliasing = 0;
            sliderText.text = "Anti Aliasing: Off";
        }

        //Set AA x2
        else if (sliderValue == 1)
        {
            QualitySettings.antiAliasing = 2;
            sliderText.text = "Anti Aliasing: 2x";
        }

        //Set AA x4
        else if (sliderValue == 2)
        {
            QualitySettings.antiAliasing = 4;
            sliderText.text = "Anti Aliasing: 4x";
        }

        //Set AA x8
        else if (sliderValue == 3)
        {
            QualitySettings.antiAliasing = 8;
            sliderText.text = "Anti Aliasing: 8x";
        }
    }
}
