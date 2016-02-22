using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionShadowDist : MonoBehaviour
{
    public Dropdown dropdownShadowDistance;

    void Update()
    {

        if (dropdownShadowDistance.value == 0)
        {
            QualitySettings.shadowDistance = 15;
        }

        else if (dropdownShadowDistance.value == 1)
        {
            QualitySettings.shadowDistance = 30;
        }

        else if (dropdownShadowDistance.value == 2)
        {
            QualitySettings.shadowDistance = 55;
        }

        else if (dropdownShadowDistance.value == 3)
        {
            QualitySettings.shadowDistance = 100;
        }
    }
}