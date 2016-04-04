using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionvSync : MonoBehaviour
{
    private Dropdown dropDown;
    [HideInInspector] public int _vSyncValue;

    void Awake()
    {
        dropDown = GetComponent<Dropdown>();
        dropDown.value = _vSyncValue;
    }

    public void VsyncChanged(int value)
    {
        _vSyncValue = value;

        //vSync is enabled
        if (value == 0)
            QualitySettings.vSyncCount = 1;

        //vSync is disabled
        else if (value == 1)
            QualitySettings.vSyncCount = 0;
    }
}