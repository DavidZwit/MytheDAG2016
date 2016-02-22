using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionAF : MonoBehaviour
{ 
    public Dropdown dropdownAF;

	void Update ()
    {
        if (dropdownAF.value == 0)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }

        else if (dropdownAF.value == 1)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        }

        else if (dropdownAF.value == 2)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }
    }
}
