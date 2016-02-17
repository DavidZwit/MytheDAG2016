using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionAF : MonoBehaviour
{ 
    [SerializeField] Dropdown _dropdownAF;
    
	void Update ()
    {
	    if (_dropdownAF.value == 0)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        }

        else if (_dropdownAF.value == 1)
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }

        else
        {
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }
    }
}
