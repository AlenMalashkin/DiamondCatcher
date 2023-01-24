using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundInvoker : MonoBehaviour
{
    public static SoundInvoker instance;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _ambientClip;
    [SerializeField] private AudioClip _hurtClip;
    [SerializeField] private AudioClip _itemHitGroundClip;
    [SerializeField] private AudioClip _slurpClip;
    [SerializeField] private AudioClip _onButtonClick;
     
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance.gameObject);
        
        PlayAmbient();
    }

    public void PlayAmbient()
    {
        _audioSource.clip = _ambientClip;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    public void PlayHurtClip()
    {
        _audioSource.PlayOneShot(_hurtClip);        
    }

    public void PlayItemHitGroundClip()
    {
        _audioSource.PlayOneShot(_itemHitGroundClip);
    }

    public void PlaySlurpClip()
    {
        _audioSource.PlayOneShot(_slurpClip);
    }
    
    public void PlayOnButtonClickClip()
    {
        _audioSource.PlayOneShot(_onButtonClick);
    }
}
