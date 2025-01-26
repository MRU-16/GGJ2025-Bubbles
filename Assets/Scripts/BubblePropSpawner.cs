using UnityEngine;

public class BubblePropSpawner : MonoBehaviour
{
    [SerializeField] private int _numberOfBubbles;
    [SerializeField] private GameObject _bubblePrefab;
    private void Awake()
    {
        for (int i = 0; i < _numberOfBubbles; i++)
        {
            GameObject bubble=Instantiate(_bubblePrefab, Vector3.zero, Quaternion.identity);
            bubble.transform.localScale *= Random.Range(0.5f, 3f);
        }
    }
}
