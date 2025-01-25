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
        Debug.Log("Contact");
        ThirdPersonController controller = collision.gameObject.GetComponentInParent<ThirdPersonController>();
        if (controller != null)
        {
            Debug.Log("Good Contact");
            controller.Jump(_bounceHeight, true);
            _onBounce.Invoke();
        }
    }
}
