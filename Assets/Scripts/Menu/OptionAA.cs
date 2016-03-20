using UnityEngine;
using System.Collections;

public class OptionAA : MonoBehaviour
{
    public int _aaValue;

    public void AAChanged(int value)
    {
        _aaValue = value;

        //Set AA off
        if (value == 0)
            QualitySettings.antiAliasing = 0;

        //Set AA x2
        else if (value == 1)
            QualitySettings.antiAliasing = 2;

        //Set AA x4
        else if (value == 2)
            QualitySettings.antiAliasing = 4;

        //Set AA x8
        else if (value == 3)
            QualitySettings.antiAliasing = 8;
    }
}