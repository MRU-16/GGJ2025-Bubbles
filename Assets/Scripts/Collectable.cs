using System.Collections;
using PrimeTween;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float _collectionDuration;
    [SerializeField] private float _bubbleValue;
    
    private void OnTriggerEnter(Collider other)
    {
        PlatformSpawner spawner = other.GetComponentInParent<PlatformSpawner>();
        if (spawner != null)
        {
            StartCoroutine(GoToPlayer(spawner));
        }
    }

    private IEnumerator GoToPlayer(PlatformSpawner spawner)
    {
        float time = 0f;
        while (time < _collectionDuration)
        {
            time += Time.deltaTime;
            
            
            
            yield return null;
        }
        spawner.AddToBank(_bubbleValue);
        Destroy(this.gameObject);
    }
}
