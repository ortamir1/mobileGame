using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class inputManager : MonoBehaviourSingleton<inputManager>
{
    
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion
    
    private PlayerInput _playerInput;
    private Camera _mainCamera;
    
    void Awake()
    {
        _playerInput = new PlayerInput();
        _mainCamera = Camera.main;
    }
    

    private void OnEnable()
    {
        _playerInput.Enable();
    }
    
    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _playerInput.Touch.primaryContact.started += ctx => StartTouchPrimary(ctx);
        _playerInput.Touch.primaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }


    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (!OnStartTouch.Equals(null)) OnStartTouch(mapper.ScreenToWorld(_mainCamera, _playerInput.Touch.primaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
    
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (!OnEndTouch.Equals(null)) OnEndTouch(mapper.ScreenToWorld(_mainCamera, _playerInput.Touch.primaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    public Vector2 PrimaryPosition()
    {
        return mapper.ScreenToWorld(_mainCamera, _playerInput.Touch.primaryPosition.ReadValue<Vector2>());
    }
    
}