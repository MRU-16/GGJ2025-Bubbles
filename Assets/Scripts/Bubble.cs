using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Bubble : Platform
{
    [SerializeField, Header("Bubble Settings")] private float _bubbleLifespan;
    [SerializeField, Header("Events")] private UnityEvent _onBubbleExpired;
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
}
