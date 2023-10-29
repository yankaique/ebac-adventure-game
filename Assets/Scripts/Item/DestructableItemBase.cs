using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;

    public float shakeDuration = 1.0f;

    [Header("Coin Drop")]
    public GameObject coinPrefab;
    public Transform dropPosition;
    public int dropCoinsAmount = 10;

    public int shakeForce = 1;

    private void OnValidate()
    {
        if(healthBase == null) healthBase = GetComponent<HealthBase>();
    }

    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
    }

    private void OnDamage(HealthBase h)
    {
        transform.DOShakeScale(shakeDuration, Vector3.up, shakeForce);
        DropGroupOfCoins();
    }

    private void DropCoins()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
    }

    private void DropGroupOfCoins()
    {
        StartCoroutine(DropGroupOfCoinsCoroutine());
    }

    IEnumerator DropGroupOfCoinsCoroutine()
    {
        for (int i = 0; i < dropCoinsAmount; i++)
        {
            DropCoins();
            yield return new WaitForSeconds(.1f);
        }
    }

}
