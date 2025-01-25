using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killz : MonoBehaviour
{
    [SerializeField] private ThirdPersonController playerChar;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerChar.transform.position = respawnPoint.position;
        }
    }
}
