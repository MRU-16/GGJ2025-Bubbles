using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceHeight;
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Contact");
        ThirdPersonController controller = collision.gameObject.GetComponentInParent<ThirdPersonController>();
        if (controller != null)
        {
            Debug.Log("Good Contact");
            controller.Jump(_bounceHeight, true);
        }
    }
}
