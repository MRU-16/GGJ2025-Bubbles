using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField, Header("Spawning")] private string _menuSceneName;
    [SerializeField] private Transform _lastCheckpoint;
    
    [SerializeField,Header("HUD")] private Image _image;
    [SerializeField] private Color _clear;
    [SerializeField] private Color _faded;
    [SerializeField] private float _fadeDuration;

    [SerializeField] private bool _fadeOutTest;

    private void Update()
    {
        if (_fadeOutTest)
        {
            _fadeOutTest = false;
            FadeScreen(false);
        }
    }
    
    public void FadeScreen(bool fadingIn)
    {
        if(fadingIn) Tween.Color(_image, _clear, _fadeDuration);
        else Tween.Color(_image, _faded, _fadeDuration);
    }
}
