using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BubblePattern : MonoBehaviour
{
    [SerializeField] private Vector2 _velocityRange;

    [SerializeField] private float _forceMag;
    
    private Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = new Vector3(Random.Range(_velocityRange.x, _velocityRange.y), Random.Range(_velocityRange.x, _velocityRange.y), Random.Range(_velocityRange.x, _velocityRange.y));
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > 30f)
        {
            transform.position = -transform.position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 force=new Vector3(Random.Range(_velocityRange.x, _velocityRange.y), Random.Range(_velocityRange.x, _velocityRange.y), Random.Range(_velocityRange.x, _velocityRange.y));
        force.x = Mathf.Sin(force.x) * _forceMag;
        force.y = Mathf.Sin(force.y) * _forceMag;
        force.z = Mathf.Sin(force.z) * _forceMag;
    }
}