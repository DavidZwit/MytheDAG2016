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
    private int aaValue;
    public int AAValue { get { return aaValue; } }

    void Awake()
    {
        optionShadowRes = GameObject.Find("DropdownShadowRes").GetComponent<OptionShadowRes>();
        optionShadowDist = GameObject.Find("DropdownShadowDist").GetComponent<OptionShadowDist>();
        optionTextureRes = GameObject.Find("DropdownTextureRes").GetComponent<OptionTextureRes>();
        optionvSync = GameObject.Find("DropdownvSync").GetComponent<OptionvSync>();
        optionAF = GameObject.Find("DropdownAF").GetComponent<OptionAF>();
        optionAA = GameObject.Find("DropdownAA").GetComponent<OptionAA>();
    }

    void Update()
    {

        if (PlayerPrefs.HasKey("TextureResValue"))
            print("We have a Save!");
        else
            print("NO SAVE!");
    }

    public void SaveSettings()
    {
        shadowResValue = optionShadowRes._shadowResValue;
        shadowDistValue = optionShadowDist._shadowDistValue;
        textureResValue = optionTextureRes._textureResValue;
        vsyncValue = optionvSync._vSyncValue;
        afValue = optionAF._afValue;
        aaValue = optionAA._aaValue;
        PlayerPrefs.SetInt("ShadowResValue", shadowResValue);
        PlayerPrefs.SetInt("ShadowDistValue", shadowDistValue);
        PlayerPrefs.SetInt("TextureResValue", textureResValue);
        PlayerPrefs.SetInt("DropdownvSync", vsyncValue);
        PlayerPrefs.SetInt("AFValue", afValue);
        PlayerPrefs.SetInt("AAValue", aaValue);
        print("I Just Saved!");
    }

    public void LoadSettings()
    {
        shadowResValue = PlayerPrefs.GetInt("ShadowResValue");
        shadowDistValue = PlayerPrefs.GetInt("ShadowDistValue");
        textureResValue = PlayerPrefs.GetInt("TextureResValue");
        vsyncValue = PlayerPrefs.GetInt("DropdownvSync");
        afValue = PlayerPrefs.GetInt("AFValue");
        aaValue = PlayerPrefs.GetInt("AAValue");
        optionShadowRes._shadowResValue = shadowResValue;
        optionShadowDist._shadowDistValue = shadowDistValue;
        optionTextureRes._textureResValue = textureResValue;
        optionvSync._vSyncValue = vsyncValue;
        optionAF._afValue = afValue;
        optionAA._aaValue = aaValue;
        print("I Just Loaded!");
    }
}