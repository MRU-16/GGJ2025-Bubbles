using System;
using System.Collections;
using PrimeTween;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlippingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _upReference;
    [SerializeField] private Transform _downReference;

    [SerializeField] private float _flipTime = 0.5f;
    [SerializeField] private Ease _flipEase;

    [SerializeField] private float _flipCooldown;

    [Header("Events")] 
    [SerializeField] private UnityEvent OnFlip;
    
    private bool _isUpright = false;

    private void Start()
    {
        StartCoroutine(FlipCooldown());
    }

    private void DetectFlipEnd()
    {
        StartCoroutine(FlipCooldown());
    }

    private IEnumerator FlipCooldown()
    {
        yield return new WaitForSeconds(_flipCooldown);
        Flip();
    }
    
    private void Flip()
    {
        Debug.Log("Flipping");
        _isUpright = !_isUpright;
        if (!_isUpright) Tween.Rotation(transform, _upReference.rotation, _flipTime, _flipEase);
        if (_isUpright) Tween.Rotation(transform, _downReference.rotation, _flipTime, _flipEase);
        StartCoroutine(FlipCooldown());
    }
}
