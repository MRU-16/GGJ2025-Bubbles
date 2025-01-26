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

    [SerializeField] private float _scalingMag;
    
    [SerializeField] private Ease _ease;
    private void Start()
    { 
        StartCoroutine(Lifespan());
    }

    private IEnumerator Lifespan()
    {
        yield return new WaitForSeconds(_bubbleLifespan * 0.95f);
        StartCoroutine(BubbleExpire());
        
        yield return new WaitForSeconds(_bubbleLifespan * 0.05f);
        _onBubbleExpired?.Invoke();
        Destroy(this.gameObject);
    }

    protected override void JumpEffects()
    {
        Tween.ShakeScale(_bubbleMesh, _scalingMagnitude, _scalingDuration);
    }

    private IEnumerator BubbleExpire()
    {
        Vector3 scale = _bubbleMesh.localScale;
        float time = 0f;
        while (time < _bubbleLifespan * 0.05f)
        {
            time += Time.deltaTime;
            scale *= 1 + time * _scalingMag;
            _bubbleMesh.localScale = scale;
            yield return null;
        }
    }
    
}
