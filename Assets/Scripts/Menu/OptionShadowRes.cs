using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionShadowRes : MonoBehaviour
{
    public Dropdown dropdownShadowResolition;

	void Update ()
    {
        if (dropdownShadowResolition.value == 0)
        {
            QualitySettings.SetQualityLevel(6, false);
        }

        else if (dropdownShadowResolition.value == 1)
        {
            QualitySettings.SetQualityLevel(7, false);
        }

        else if (dropdownShadowResolition.value == 2)
        {
            QualitySettings.SetQualityLevel(8, false);
        }
    }
}
