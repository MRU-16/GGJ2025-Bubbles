using PrimeTween;
using UnityEngine;

public class TextAnimator : MonoBehaviour
{
    [SerializeField] private Vector3 _intensity;
    
    public void Click()
    {
        Tween.ShakeScale(transform, _intensity, 0.2f);
    }
}
