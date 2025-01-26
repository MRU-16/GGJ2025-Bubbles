using System.Collections;
using PrimeTween;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : ButtonBase
{
    [SerializeField, Range(0f, 10f)] private float _clickDelay = 0.5f;
    [SerializeField] private Image _fadeImage;
    
    private void Start()
    {
        Tween.Color(_fadeImage, new Color(1f, 1f, 1f, 0f), _clickDelay);
    }
    
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;

        if (_clickDelay == 0f) SceneManager.LoadScene(sceneName);
        else StartCoroutine(DelayedLoadScene(sceneName));
        Tween.Color(_fadeImage, new Color(1f, 1f, 1f, 1f), _clickDelay);
    }

    private IEnumerator DelayedLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(_clickDelay);
        SceneManager.LoadScene(sceneName);
    }
}
