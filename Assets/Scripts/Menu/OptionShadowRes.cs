using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionShadowRes : MonoBehaviour
{
    private Dropdown dropDown;
    [HideInInspector] public int _shadowResValue;

    void Awake()
    {
        dropDown = GetComponent<Dropdown>();
        dropDown.value = _shadowResValue;
    }

    public void ShadowResChanged (int value)
    {
        _shadowResValue = value;

        //Low
        if (value == 0)
            QualitySettings.SetQualityLevel(6, false);

        //Medium
        else if (value == 1)
            QualitySettings.SetQualityLevel(7, false);

        //High
        else if (value == 2)
            QualitySettings.SetQualityLevel(8, false);
    }
}
