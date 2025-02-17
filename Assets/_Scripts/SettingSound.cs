using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour
{
    [SerializeField] Image iconSound;
    [SerializeField] Sprite soundOn;
    [SerializeField] Sprite soundOff;

    [SerializeField] Image iconMusic;
    [SerializeField] Sprite musicOn;
    [SerializeField] Sprite musicOff;

    public void SetUpIconSound(bool on)
    {
        iconSound.sprite = on ? soundOn : soundOff;
    }
    public void SetUpIconMusic(bool on)
    {
        iconMusic.sprite = on ? musicOn : musicOff;
    }
}
