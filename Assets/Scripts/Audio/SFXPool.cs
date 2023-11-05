using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

public class SFXPool : Singleton<SFXPool>
{
   private List<AudioSource> _audioSources;
    public int poolSize = 10;
    private int _index = 0;

    private void Start()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _audioSources = new List<AudioSource>();
        for(int i = 0; i < poolSize; i++)
        {
            CreateAudioSourceItem();
        }
    }

    private void CreateAudioSourceItem()
    {
        GameObject go = new GameObject("SFX_Pool");
        go.transform.SetParent(gameObject.transform);
        _audioSources.Add(go.AddComponent<AudioSource>());
    }

    public void Play(SFXType sfxType)
    {
        if (sfxType == SFXType.NONE) return;
        var sfx = SoundManager.Instance.GetSFXByType(sfxType);
        _audioSources[_index].clip = sfx.audioClip;
        _audioSources[_index].Play();

        _index++;
        if (_index >= _audioSources.Count) _index = 0;
    }
}
