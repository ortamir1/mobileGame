using UnityEngine;

public abstract class Indicator : MonoBehaviour
{
    protected inputManager _inputManager;
    
    private void Awake()
    {
        _inputManager = inputManager.Instance;
    }
    
    private void OnEnable()
    {
        _inputManager.OnStartTouch += StartIndication;
        _inputManager.OnEndTouch += StopIndication;
    }
    
    private void OnDisable()
    {
        _inputManager.OnStartTouch -= StartIndication;
        _inputManager.OnEndTouch -= StopIndication;
    }
    
    public abstract void StartIndication(Vector2 position, float time);
    
    public abstract void StopIndication(Vector2 position, float time);
}