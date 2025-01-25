using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

[RequireComponent(typeof(Rigidbody))]
public class TrackObstacle : MonoBehaviour
{
    
    [SerializeField] private SplineContainer _track;

    [SerializeField] private float _speedMultiplier;

    private Rigidbody _rb;
    
    private float _time = 0f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _track = GetComponent<SplineContainer>();
    }
    
    private void Update()
    {
        _time += Time.deltaTime * _speedMultiplier;
        float3 position;
        float3 tangent;
        float3 up;
        _track.Evaluate(_time, out position, out tangent, out up);

        _rb.position = position;
    }

}
