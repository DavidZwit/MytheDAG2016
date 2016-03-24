using UnityEngine;
using System.Collections;

public class TestBerend : MonoBehaviour
{
    public int _shadowValue;

    public void shadowDistanceChanged(int value)
    {
        _shadowValue = value;

        if (value == 0)
        {
            QualitySettings.shadowDistance = 15;
        }

        else if (value == 1)
        {
            QualitySettings.shadowDistance = 30;
        }

        else if (value == 2)
        {
            QualitySettings.shadowDistance = 55;
        }

        else if (value == 3)
        {
            QualitySettings.shadowDistance = 100;
        }
    }
}