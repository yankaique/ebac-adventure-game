using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open";

    [Header("Notification")]
    public GameObject notification;
    public float tweenDuration = .2f;
    public Ease tweenEase = Ease.OutBack;
    private float startScale;

    public void Start()
    {
        startScale = notification.transform.localScale.x;
        HideNotification(); 
    }

    [NaughtyAttributes.Button]
    public void OpenChest()
    {
        animator.SetTrigger(triggerOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if (p != null)
        {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Player p = other.GetComponent<Player>();

        if (p != null)
        {
            HideNotification();
        }
    }

    [NaughtyAttributes.Button]
    private void ShowNotification()
    {
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale, tweenDuration).SetEase(tweenEase);
    } 

    [NaughtyAttributes.Button]
    private void HideNotification()
    {
        notification.SetActive(false);
    }


}
