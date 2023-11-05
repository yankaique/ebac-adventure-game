using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;
    public SFXType sfxType;

    private bool _checkPointActived = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!_checkPointActived && other.transform.tag == "Player")
        {
            VerifyCheckPoint();
        }
    }

    public void VerifyCheckPoint()
    {
        SaveCheckPoint();
        TurnItOn();
    }

    public void PlaySFX()
    {
        SFXPool.Instance.Play(sfxType);
    }
    public void TurnItOn()
    {
        PlaySFX();
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    } 

    public void TurnItOff()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }

    public void SaveCheckPoint()
    {
        CheckPointManager.Instance.SaveCheckPoint(key);
        _checkPointActived = true;
        SaveManager.Instance.SaveCheckpoint(key);
    }
}
