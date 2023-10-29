using DG.Tweening;
using Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestItemCoin : ChestItemBase
{
    public int coinNumber = 5;
    public GameObject coinObject;

    [Header("Randomize Values")]
    public Vector2 randomRange = new Vector2(-2f, 2f);

    private List<GameObject> _itens = new List<GameObject>();

    [Space]
    public float tweenEndTime = .5f;

    public override void ShowItem()
    {
        base.ShowItem();
        CreateItems();
    }
    [NaughtyAttributes.Button]

    private void CreateItems()
    {
        for(int i = 0; i < coinNumber; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position 
                + Vector3.forward * Random.Range(randomRange.x, randomRange.y) 
                + Vector3.right * Random.Range(randomRange.x, randomRange.y);
            item.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
            _itens.Add(item);
        }
    }

    [NaughtyAttributes.Button]
    public override void Collect()
    {
        base.Collect();
        foreach(var item in _itens)
        {
            item.transform.DOMoveY(2f, tweenEndTime).SetRelative();
            item.transform.DOScale(0, tweenEndTime/2).SetDelay(tweenEndTime/2);
            ItemManager.Instance.AddByType(ItemType.COIN);
        }
    }
}
