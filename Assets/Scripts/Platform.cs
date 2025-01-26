using StarterAssets;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    [SerializeField, Header("Events")] protected UnityEvent _onBounce;
    [SerializeField, Header("Preferences")] protected float _bounceHeight;

    protected void OnTriggerEnter(Collider collision)
    {
        ThirdPersonController controller = collision.gameObject.GetComponentInParent<ThirdPersonController>();
        if (controller != null)
        {
            controller.Jump(_bounceHeight, true);
            _onBounce.Invoke();
            JumpEffects();
        }
    }

    protected virtual void JumpEffects()
    {
        
    }
}
