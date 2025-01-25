using System.Collections;
using PrimeTween;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField, Header("Spawning")] private string _menuSceneName;
    [SerializeField] private Transform _lastCheckpoint;
    
    [SerializeField] private float _menuDelay;
    
    [SerializeField,Header("HUD")] private Image _image;
    [SerializeField] private Color _clear;
    [SerializeField] private Color _winFade;
    [SerializeField] private Color _deadFade;
    [SerializeField] private float _fadeDuration;

    [SerializeField] private bool _fadeOutTest;

    private void Start()
    {
        _image.color = _winFade;
        FadeScreen(true, _deadFade);
    }
    
    private void Update()
    {
        if (_fadeOutTest)
        {
            _fadeOutTest = false;
            FadeScreen(false, _winFade);
        }
    }

    public void Win()
    {
        FadeScreen(false, _winFade);
        StartCoroutine(SwitchScene(_menuSceneName, _menuDelay));
    }

    public void Lose()
    {
        FadeScreen(false, _deadFade);
        StartCoroutine(SwitchScene(_menuSceneName, _menuDelay));
    }

    public void FadeScreen(bool fadingIn, Color endGame)
    {
        if (fadingIn) Tween.Color(_image, _clear, _fadeDuration);
        else Tween.Color(_image, endGame, _fadeDuration);
    }

    private IEnumerator SwitchScene(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
