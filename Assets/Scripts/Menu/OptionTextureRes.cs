using UnityEngine;
using System.Collections;

public class OptionTextureRes : MonoBehaviour
{
    public int _textureResValue;

    public void TextureResChanged(int value)
    {
        _textureResValue = value;

        //Very Low
        if (value == 0)
            QualitySettings.masterTextureLimit = 3;

        //Low
        else if (value == 1)
            QualitySettings.masterTextureLimit = 2;

        //Medium
        else if (value == 2)
            QualitySettings.masterTextureLimit = 1;

        //High
        else if (value == 3)
            QualitySettings.masterTextureLimit = 0;
    }
}
