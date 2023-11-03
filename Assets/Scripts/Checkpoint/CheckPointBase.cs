using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;

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

    [NaughtyAttributes.Button]
    public void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    } 

    [NaughtyAttributes.Button]

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
