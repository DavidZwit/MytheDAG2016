using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionvSync : MonoBehaviour
{
    [SerializeField] private Toggle togglevSync;
    [SerializeField] private Text toggleText;

	void Update ()
    {
        //If toggled on; vSync is enabled
        if (togglevSync.isOn == true)
        {
            QualitySettings.vSyncCount = 1;
            toggleText.text = "On";
        }

        //If toggled off; vSync is disabled
        else
        {
            QualitySettings.vSyncCount = 0;
            toggleText.text = "Off";
        }
	}
}
