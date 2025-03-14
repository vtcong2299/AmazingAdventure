using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource audioBGM;
    [SerializeField] AudioSource audioSFX;
    [SerializeField] AudioClip clickButtonClip;
    [SerializeField] AudioClip bgmClip;
    [SerializeField] AudioClip getCoinsClip;
    [SerializeField] AudioClip finishClip;
    [SerializeField] AudioClip starsClip;
    [SerializeField] AudioClip hpClip;
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip deadClip;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        SoundBGM();
    }

    public void Start()
    {
        SetVolumAudioBGM(DataManager.Instance.gameData.hasBGM);
        SetVolumAudioSFX(DataManager.Instance.gameData.hasSFX);
    }

    public void SetVolumAudioBGM(bool state)
    {
        audioBGM.volume = state ? 0.5f : 0;
    }

    public void SetVolumAudioSFX(bool state)
    {
        audioSFX.volume = state ? 1f : 0;
    }

    public void SoundClickButton()
    {
        audioSFX.clip = clickButtonClip;
        audioSFX.Play();
    }

    void SoundBGM()
    {
        audioBGM.clip = bgmClip;
        audioBGM.loop = true;
        audioBGM.Play();
    }

    public void SoundGetCoin()
    {
        audioSFX.clip = getCoinsClip;
        audioSFX.Play();
    }

    public void SoundFinish()
    {
        audioSFX.clip = finishClip;
        audioSFX.Play();
    }

    public void SoundStars()
    {
        audioSFX.clip = starsClip;
        audioSFX.Play();
    }

    public void SoundHit()
    {
        audioSFX.clip = hitClip;
        audioSFX.Play();
    }

    public void SoundDead()
    {
        audioSFX.clip = deadClip;
        audioSFX.Play();
    }

    public void SoundGetHp()
    {
        audioSFX.clip = hpClip;
        audioSFX.Play();
    }
}
