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

    [Header("Player Actions")]
    public KeyCode keyToOpenChest = KeyCode.LeftControl;

    [Header("Chest Item Props")]
    public ChestItemBase chestItem;


    private bool _chestOpened = false;

    public void Start()
    {
        startScale = notification.transform.localScale.x;
        HideNotification(); 
    }

    [NaughtyAttributes.Button]
    public void OpenChest()
    {
        if (!_chestOpened)
        {
            animator.SetTrigger(triggerOpen);
            _chestOpened = true;
            HideNotification();
            Invoke(nameof(ShowItem), 1f);
        }
    }

    private void ShowItem()
    {
        chestItem.ShowItem();
        Invoke(nameof(CollectItem), 1f);
    }

    private void CollectItem()
    {
        chestItem.Collect();
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

    private void Update()
    {
        if(Input.GetKeyDown(keyToOpenChest) && !_chestOpened) { 
            OpenChest();
        }
    }
}
