using UnityEngine;
using System.Collections;

public class SavePlayerSettings : MonoBehaviour
{
    private OptionShadowRes optionShadowRes;
    private OptionShadowDist optionShadowDist;
    private OptionTextureRes optionTextureRes;
    private OptionvSync optionvSync;
    private OptionAF optionAF;
    private OptionAA optionAA;
    //private TestBerend berendlol;

    private int shadowResValue;
    public int ShadowResValue { get { return shadowResValue; } }
    private int shadowDistValue;
    public int ShadowDistValue { get { return shadowDistValue; } }
    private int textureResValue;
    public int TextureResValue { get { return textureResValue; } }
    private int vsyncValue;
    public int VsyncValue { get { return vsyncValue; } }
    private int afValue;
    public int AFValue { get { return afValue; } }
    private float aaValue;
    public float AAValue { get { return aaValue; } }

    void Awake()
    {
        optionShadowRes = GameObject.Find("DropdownShadowRes").GetComponent<OptionShadowRes>();
        optionShadowDist = GameObject.Find("DropdownShadowDist").GetComponent<OptionShadowDist>();
        optionTextureRes = GameObject.Find("DropdownTextureRes").GetComponent<OptionTextureRes>();
        optionvSync = GameObject.Find("DropdownvSync").GetComponent<OptionvSync>();
        optionAF = GameObject.Find("DropdownAF").GetComponent<OptionAF>();
        optionAA = GameObject.Find("SliderAA").GetComponent<OptionAA>();
    }

    void Update()
    {
        //print(berendlol._shadowValue);
    }

    public void SaveSettings()
    {
        shadowResValue = optionShadowRes.dropdownShadowResolition.value;
        shadowDistValue = optionShadowDist.dropdownShadowDistance.value;
        textureResValue = optionTextureRes.dropdownTextureResolition.value;
        vsyncValue = optionvSync._dropdownvSync.value;
        afValue = optionAF.dropdownAF.value;
        aaValue = optionAA.sliderAA.value;
        PlayerPrefs.SetInt("ShadowResValue", shadowResValue);
        PlayerPrefs.SetInt("ShadowDistValue", shadowDistValue);
        PlayerPrefs.SetInt("TextureResValue", textureResValue);
        PlayerPrefs.SetInt("DropdownvSync", vsyncValue);
        PlayerPrefs.SetInt("AFValue", afValue);
        PlayerPrefs.SetFloat("AAValue", aaValue);
    }

    public void LoadSettings()
    {
        shadowResValue = PlayerPrefs.GetInt("ShadowResValue");
        shadowDistValue = PlayerPrefs.GetInt("ShadowDistValue");
        textureResValue = PlayerPrefs.GetInt("TextureResValue");
        vsyncValue = PlayerPrefs.GetInt("DropdownvSync");
        afValue = PlayerPrefs.GetInt("AFValue");
        aaValue = PlayerPrefs.GetFloat("AAValue");
        optionShadowRes.dropdownShadowResolition.value = shadowResValue;
        optionShadowDist.dropdownShadowDistance.value = shadowDistValue;
        optionTextureRes.dropdownTextureResolition.value = textureResValue;
        optionvSync._dropdownvSync.value = vsyncValue;
        optionAF.dropdownAF.value = afValue;
        optionAA.sliderAA.value = aaValue;
    }
}