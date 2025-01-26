using System.Collections;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField, Header("Spawning")] private string _menuSceneName;
    public Transform LastCheckpoint { get; set; }
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _initialCheckpoint;
    [SerializeField] private float _menuDelay;
    [SerializeField] private Image _fillBar;
    [SerializeField,Header("HUD")] private Image _image;
    [SerializeField] private Color _clear;
    [SerializeField] private Color _winFade;
    [SerializeField] private Color _deadFade;
    [SerializeField] private float _fadeDuration;

    [Header("Testing")]
    [SerializeField] private bool _fadeOutTest;
    [SerializeField] private Vector3 _spawnPosition;
    
    [field: SerializeField] public bool CanSpawnBubble { get; set; }

    private void Start()
    {
        LastCheckpoint=_initialCheckpoint;
        
        _image.color = _winFade;
        FadeScreen(true, _deadFade);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    
    private void Update()
    {
        if (_fadeOutTest)
        {
            _fadeOutTest = false;
            ReturnToCheckPoint(_spawnPosition);
        }
    }

    public void Win()
    {
        FadeScreen(false, _winFade);
        StartCoroutine(SwitchScene(_menuSceneName, _menuDelay));
    }

    public void Lose()
    {
        Debug.Log("Losing");
        StartCoroutine(Respawn());
    }

    public void FadeScreen(bool fadingIn, Color endGame)
    {
        if (fadingIn) Tween.Color(_image, _clear, _fadeDuration);
        else Tween.Color(_image, endGame, _fadeDuration);
    }

    public void ChangeBubbleAmount(float ratio)
    {
        _fillBar.fillAmount = ratio;
    }

    private IEnumerator SwitchScene(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator Respawn()
    {
        FadeScreen(false, _winFade);
        yield return new WaitForSeconds(_fadeDuration);
        ReturnToCheckPoint(LastCheckpoint.position);
        Debug.Log(LastCheckpoint.position);
        FadeScreen(true, _winFade);
    }

    private void ReturnToCheckPoint(Vector3 checkpoint)
    {
        for (int i = 0; i < 100; i++)
        {
            Debug.Log($"Player at {_player.position}, Moving to {checkpoint}");
            _player.transform.position = checkpoint + new Vector3(0f, 10f, 0f);
        }
    }
}
