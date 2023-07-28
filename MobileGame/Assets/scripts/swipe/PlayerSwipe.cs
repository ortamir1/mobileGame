using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSwipe: swipeDetection
{
    
    [SerializeField] private float _movementModifier = 5f;
        
    [SerializeField] private float _timeModifier = 10f;
    
    [SerializeField] private float _minimumDistanceFromPlayer = 3f;
    
    [SerializeField] private Rigidbody2D _playerRigidBody;
    
    [SerializeField] private float _pullModifier = 100f;
    
    public override void SwipeBehaviour(Vector2 direction, Vector2 startPosition, float power)
    {
        if (IsNearPlayer(startPosition))
        {
            _playerRigidBody.AddForce(-direction * power, ForceMode2D.Force);
        }
    }

    protected override float CalculatePower(float distance, float time)
    {
        return _pullModifier * math.sqrt(math.max(time* _timeModifier, 1) * math.max(distance * _movementModifier, 1));
    }

    private Boolean IsNearPlayer(Vector3 position)
    {
        return Vector3.Distance(position, _playerRigidBody.position) <= _minimumDistanceFromPlayer;
    }
}