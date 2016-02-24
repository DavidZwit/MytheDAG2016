using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionShadowDist : MonoBehaviour
{
    [SerializeField] private Dropdown dropdownShadowDistance;
    private float dropdownValue;

    void Update()
    {
        dropdownValue = dropdownShadowDistance.value;

        if (dropdownValue == 0)
        {
            QualitySettings.shadowDistance = 15;
        }

        else if (dropdownValue == 1)
        {
            QualitySettings.shadowDistance = 30;
        }

        else if (dropdownValue == 2)
        {
            QualitySettings.shadowDistance = 55;
        }

        else if (dropdownValue == 3)
        {
            QualitySettings.shadowDistance = 100;
        }
    }
}