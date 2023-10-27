using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour
{
    public string tagToCheck = "Player";
    public GameObject bossCamera;
    public Color gizmoColor = Color.yellow;

    private void Awake()
    {
        StartCamera(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == tagToCheck)
        {
            StartCamera(true);
        }
    }

    private void StartCamera(bool cameraValue)
    {
        bossCamera.SetActive(cameraValue);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, transform.localScale.y);
    }
}
