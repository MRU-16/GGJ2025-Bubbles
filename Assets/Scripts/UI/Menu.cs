using FMODUnity;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter _emitter;
    
    
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start()
    {
        PlayTransitionNoise();
    }

    private void PlayTransitionNoise()
    {
        _emitter.Play();
    }
    
}
