using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(ThirdPersonController))]
public class PlatformSpawner : MonoBehaviour
{
    [SerializeField,Header("References")] private GameObject _platformPrefab;

    [SerializeField, Header("Preferences")] private float _spawnCooldown;
    [SerializeField] private Vector3 _spawnOffset;

    [SerializeField, Header("Events")] private UnityEvent _onPlatformSpawned;

    private bool _canSpawn = true;
    
    private ThirdPersonController _controller;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<ThirdPersonController>();
    }

    public void OnPlatform(InputValue value)
    {
        if (_controller.Grounded || !_canSpawn) return;

        Instantiate(_platformPrefab, transform.position + _spawnOffset, Quaternion.identity);
        _onPlatformSpawned.Invoke();
        StartCoroutine(SpawnCooldown());
        
        Debug.Log("Spawning Platform");
    }

    private IEnumerator SpawnCooldown()
    {
        _canSpawn = false;
        yield return new WaitForSeconds(_spawnCooldown);
        _canSpawn = true;
    }
    
    
}
