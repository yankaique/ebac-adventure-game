using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [Header("Setup")]
    public Color color = Color.red;
    public float duration = .1f;

    private Color _defaultColor;
    private Tween _currentTween;

    private void Start()
    {
        _defaultColor = meshRenderer.material.GetColor("_EmissionColor");
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if (!_currentTween.IsActive()) { 
            meshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
        }
    }

}
