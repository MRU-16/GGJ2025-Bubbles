using UnityEngine;
using UnityEngine.Events;

public class Poppable : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPopped;
    
    public void Pop()
    {
        _onPopped.Invoke();
    }   
}