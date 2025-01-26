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
    [SerializeField] private float _initialBubbles;
    [SerializeField] private float _maxBubbles;
    [SerializeField] private float _bubblesPerPlatform;
    
    [SerializeField, Header("Events")] private UnityEvent _onPlatformSpawned;

    private bool _canSpawn = true;
    private float _amountOfBubbles;
    
    private ThirdPersonController _controller;
    private PlayerInput _playerInput;
    [SerializeField] private HUD _hud;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<ThirdPersonController>();
        _amountOfBubbles = _initialBubbles;
    }

    private void Start()
    {
        _amountOfBubbles=_initialBubbles;
        Debug.Log(_amountOfBubbles);
        Debug.Log(_maxBubbles);
        Debug.Log(_amountOfBubbles/_maxBubbles);
        
        _hud.ChangeBubbleAmount(_amountOfBubbles / _maxBubbles);
    }

    public void AddToBank(float incomingBubbles)
    {
        _amountOfBubbles += incomingBubbles;
        _amountOfBubbles = Mathf.Clamp(_amountOfBubbles, 0, _maxBubbles);
        _hud.ChangeBubbleAmount(_amountOfBubbles / _maxBubbles);
    }

    public void OnPlatform(InputValue value)
    {
        if (_controller.Grounded || !_canSpawn || _amountOfBubbles < _bubblesPerPlatform) return;
        
        Instantiate(_platformPrefab, transform.position + _spawnOffset, Quaternion.identity);
        _onPlatformSpawned.Invoke();
        Debug.LogError(_amountOfBubbles + "-" + _bubblesPerPlatform);
        _amountOfBubbles -= _bubblesPerPlatform;
        Debug.LogError(_amountOfBubbles);
        _hud.ChangeBubbleAmount(_amountOfBubbles / _maxBubbles);
        StartCoroutine(SpawnCooldown());
        
        Debug.Log("Spawning Platform");
    }

    private IEnumerator SpawnCooldown()
    {
        _hud.CanSpawnBubble = false;
        _canSpawn = false;
        yield return new WaitForSeconds(_spawnCooldown);
        _canSpawn = true;
        _hud.CanSpawnBubble = true;
    }
    
    
}
