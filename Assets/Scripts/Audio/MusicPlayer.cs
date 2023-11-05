using Ebac.core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : Singleton<MusicPlayer>
{
    public MusicType musicType;
    public AudioSource audioSource;
    private MusicSetup _currentMusicSetup;


    private void Start()
    {
        Play();
    }

    public void Play()
    {
        _currentMusicSetup = SoundManager.Instance.GetMusicByType(musicType);
        audioSource.clip = _currentMusicSetup.audioClip;
        audioSource.Play();
    }  
    
    public void Stop()
    {
        _currentMusicSetup = SoundManager.Instance.GetMusicByType(musicType);
        audioSource.clip = _currentMusicSetup.audioClip;
        audioSource.Stop();
    }
}
