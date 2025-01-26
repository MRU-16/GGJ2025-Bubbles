using System.Collections;
using PrimeTween;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float _collectionBuffer = 0.3f;
    [SerializeField] private float _collectionSpeed = 12f;
    [SerializeField] private float _bubbleValue = 1f;
    
    [SerializeField] private UnityEvent _onCollect;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contact");
        PlatformSpawner spawner = other.GetComponentInParent<PlatformSpawner>();
        if (spawner != null)
        {
            Debug.Log("Spawner Intercepted");
            StartCoroutine(GoToPlayer(spawner));
        }
    }

    private IEnumerator GoToPlayer(PlatformSpawner spawner)
    {
        _onCollect.Invoke();
        while (_collectionBuffer <Vector3.Distance(transform.position, spawner.transform.position))
        {
            transform.Translate((spawner.transform.position - transform.position) * Time.deltaTime * _collectionSpeed);
            yield return null;
        }
        spawner.AddToBank(_bubbleValue);
        Destroy(this.gameObject);
    }
}
