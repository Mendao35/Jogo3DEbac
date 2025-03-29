using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColorNew : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [Header("Setups")]
    public Color color = Color.red;
    public float duration = 0.1f;

    private Color defaultColor;

    private Tween _currentTeew;

    private void Start()
    {
        defaultColor = meshRenderer.material.GetColor("_EmissionColor");
    }

    [NaughtyAttributes.Button]
    public void Flash()
    {
        if(!_currentTeew.IsActive())
        _currentTeew =  meshRenderer.material.DOColor(color, "_EmissionColor", duration).SetLoops(2, LoopType.Yoyo);
    }
}
