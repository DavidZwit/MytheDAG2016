using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionvSync : MonoBehaviour
{
    public Dropdown _dropdownvSync;

    void Update()
    {
        //If toggled on; vSync is enabled
        if (_dropdownvSync.value == 0)
        {
            QualitySettings.vSyncCount = 1;
        }

        //If toggled off; vSync is disabled
        else if (_dropdownvSync.value == 1)
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}