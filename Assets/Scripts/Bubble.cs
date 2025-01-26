using System.Collections;
using PrimeTween;
using UnityEngine;
using UnityEngine.Events;

public class Bubble : Platform
{
    [SerializeField, Header("Bubble Settings")] private float _bubbleLifespan;
    [SerializeField, Header("Events")] private UnityEvent _onBubbleExpired;
    [SerializeField, Header("Bounce Effects")] private Transform _bubbleMesh;
    [SerializeField] private Vector3 _scalingMagnitude;
    [SerializeField] private float _scalingDuration;
    private void Start()
    { 
        StartCoroutine(Lifespan());
    }

    private IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(_bubbleLifespan);
        _onBubbleExpired?.Invoke();
        Destroy(this.gameObject);
    }

    protected override void JumpEffects()
    {
        Tween.ShakeScale(_bubbleMesh, _scalingMagnitude, _scalingDuration);
    }
}
