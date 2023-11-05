using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public List<GameObject> endGameObject;
    public int currentLevel = 8;

    private bool _endGame = false;

    private void Awake()
    {
        /*
        endGameObject.ForEach(e =>
        {
            e.SetActive(false);
        });
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (!_endGame && p != null)
        {
            ShowEndGame(); 
        }
    }

    private void ShowEndGame()
    {
        _endGame = true;
        foreach (var i in endGameObject)
        {
            // i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastLevel(currentLevel);
        }
    }
}
