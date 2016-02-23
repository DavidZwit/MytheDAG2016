using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionAF : MonoBehaviour
{ 
    [SerializeField] private Dropdown dropdownAF;
    private float dropdownValue;

	void Update ()
    {
        dropdownValue = dropdownAF.value;

        if (dropdownValue == 0)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }

        else if (dropdownValue == 1)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        }

        else if (dropdownValue == 2)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }
    }
}
