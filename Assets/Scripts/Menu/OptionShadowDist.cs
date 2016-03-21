using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionShadowDist : MonoBehaviour
{
    private Dropdown dropDown;
    [HideInInspector] public int _shadowDistValue;

    void Awake()
    {
        dropDown = GetComponent<Dropdown>();
        dropDown.value = _shadowDistValue;
    }

    public void ShadowDistanceChanged(int value)
    {
        _shadowDistValue = value;

        //Very Low
        if (value == 0)
            QualitySettings.shadowDistance = 15;

        //Low
        else if (value == 1)
            QualitySettings.shadowDistance = 30;

        //Medium
        else if (value == 2)
            QualitySettings.shadowDistance = 55;

        //High
        else if (value == 3)
            QualitySettings.shadowDistance = 100;
    }
}