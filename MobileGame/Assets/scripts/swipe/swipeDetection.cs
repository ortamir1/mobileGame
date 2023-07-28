using UnityEngine;

public abstract class swipeDetection : MonoBehaviour
{
    [SerializeField] private float _minimumDistance = .2f;
    [SerializeField] private float _maximumTime = 1f;

    
    private inputManager _inputManager;
    private Vector2 _startPosition;
    private float _startTime;

    private Vector2 _endPosition;
    private float _endTime;
    private void Awake()
    {
        _inputManager = inputManager.Instance;
    }
    
    private void OnEnable()
    {
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }
    
    private void OnDisable()
    {
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
        _startTime = time;
    }
    
    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        float distance = Vector2.Distance(_startPosition, _endPosition);
        float timeDifference = _endTime - _startTime;
        if (distance >= _minimumDistance && timeDifference <= _maximumTime)
        {
            SwipeBehaviour(CalculateDirection(_endPosition, _startPosition), _startPosition, CalculatePower(distance, timeDifference));
        }
    }

    public abstract void SwipeBehaviour(Vector2 direction, Vector2 startPosition, float power);

    protected Vector2 CalculateDirection(Vector2 A, Vector2 B)
    {
        return (A - B).normalized;
    }

    protected abstract float CalculatePower(float distance, float time);
}