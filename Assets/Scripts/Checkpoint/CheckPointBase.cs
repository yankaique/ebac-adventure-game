using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;

    private bool _checkPointActived = false;
    private string _checkPointKey = "CheckPointKey";

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
        if(PlayerPrefs.GetInt(_checkPointKey, 0) > key)
        {
            PlayerPrefs.SetInt(_checkPointKey, key);
        }

        _checkPointActived = true;
    }
}
