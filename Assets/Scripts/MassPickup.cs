using UnityEngine;
using UnityEngine.Events;

public class MassPickup : MonoBehaviour
{
    [SerializeField] private float _reward;
    [SerializeField] private UnityEvent _onPickup;
    private void OnTriggerEnter(Collider other)
    {
        PlatformSpawner spawner = other.gameObject.GetComponent<PlatformSpawner>();
        if (spawner != null)
        {
            spawner.AddToBank(_reward);
            _onPickup.Invoke();
            Destroy(this.gameObject);
        }
    }
}
