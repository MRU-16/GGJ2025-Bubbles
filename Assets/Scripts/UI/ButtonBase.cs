using UnityEngine;
using FMODUnity;

[RequireComponent(typeof(StudioEventEmitter))]
public abstract class ButtonBase : MonoBehaviour
{
    [SerializeField] protected FMODUnity.StudioEventEmitter _emitter;

    private void Awake()
    {
        if (_emitter != null) return;
        _emitter = GetComponent<FMODUnity.StudioEventEmitter>();
    }
    
    public void PlayClickSound()
    {
        _emitter.Play();
    }
}
