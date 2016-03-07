using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionTextureRes : MonoBehaviour
{
    public Dropdown dropdownTextureResolition;

    void Update()
    {
        if (dropdownTextureResolition.value == 0)
        {
            QualitySettings.masterTextureLimit = 3;
        }

        else if (dropdownTextureResolition.value == 1)
        {
            QualitySettings.masterTextureLimit = 2;
        }

        else if (dropdownTextureResolition.value == 2)
        {
            QualitySettings.masterTextureLimit = 1;
        }

        else if (dropdownTextureResolition.value == 3)
        {
            QualitySettings.masterTextureLimit = 0;
        }
    }
}
