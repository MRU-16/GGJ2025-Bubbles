using StarterAssets;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ThirdPersonController controller = other.gameObject.GetComponent<ThirdPersonController>();
        if (controller != null)
        {
            Debug.Log("Controller intercepted");
            HUD hud = controller.Hud;
            if (hud != null)
            {
                Debug.Log("Intercepted CheckPoint");
                hud.LastCheckpoint = transform;
            }
        }
    }
}
