using System.Collections;
using System.Collections.Generic;
using FlyBrid;
using GameFramework;
using UnityEngine;

public class SettingForm : UGuiForm
{
    public void OnCloseButtonClick()
    {
        Close();
    }

    public void OnMusicSettingValueChange(float value)
    {
        Log.Debug("Volume:"+value);
        GameEntry.Sound.SetVolume("Music",value);
    }

    public void OnSoundSettingValueChange(float value)
    {
        GameEntry.Sound.SetVolume("Sound",value);
        GameEntry.Sound.SetVolume("UISound",value);
    }
}
