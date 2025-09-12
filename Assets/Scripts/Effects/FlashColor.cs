using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    [Header("Setup")]
        public Color color = Color.red;
        public float duration = 0.1f;
    private Color _colorDefault;
    public string colorProperty = "_EmissionColor";
    private Tween _currentTween;
    private void OnValidate()
    {
        if (meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        if (skinnedMeshRenderer == null)
        {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }
    }

    /*private void Start()
    {
        _colorDefault = meshRenderer.material.GetColor(_colorProperty);
    }*/

    [Button]
    public void Flash()
    {
        if (meshRenderer != null && !_currentTween.IsActive())
        {
            _currentTween = meshRenderer.material.DOColor(color, colorProperty, duration).
                SetLoops(2, LoopType.Yoyo);
        }
        if (skinnedMeshRenderer != null && !_currentTween.IsActive())
        {
            _currentTween = skinnedMeshRenderer.material.DOColor(color, colorProperty, duration).
                SetLoops(2, LoopType.Yoyo);
        }
    }
}
