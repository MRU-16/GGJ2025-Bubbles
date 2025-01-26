using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class musicrepeater : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlay;
    [SerializeField] private float songLength;
    
    private void Start()
    {
        StartCoroutine(MusicTimer());
    }
    
    private IEnumerator MusicTimer()
    {
        while (true)
        {
            OnPlay.Invoke();
            yield return new WaitForSeconds(songLength);
        }
    }
    
    
}
