using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float _clickDelay = 0.5f;
    
    public void LoadScene(string sceneName)
    {
        if (_clickDelay == 0f) SceneManager.LoadScene(sceneName);
        else StartCoroutine(DelayedLoadScene(sceneName));
    }

    private IEnumerator DelayedLoadScene(string sceneName)
    {
        yield return new WaitForSeconds(_clickDelay);
        SceneManager.LoadScene(sceneName);
    }
}
