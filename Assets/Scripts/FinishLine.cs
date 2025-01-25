using StarterAssets;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ThirdPersonController controller = other.gameObject.GetComponentInParent<ThirdPersonController>();
        if (controller != null)
        {
            controller.Win();
        }
    }
}
