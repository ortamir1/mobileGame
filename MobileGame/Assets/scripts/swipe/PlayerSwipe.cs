using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSwipe: swipeDetection
{
    
    [SerializeField] private float _minimumDistanceFromPlayer = 3f;
    
    [SerializeField] private Rigidbody2D _playerRigidBody;
    
    [SerializeField] private float _pullModifier = 100f;
    
    public override void SwipeBehaviour(Vector2 direction, Vector2 startPosition, float power)
    {
        if (IsNearPlayer(startPosition))
        {
            Debug.Log(direction);
            _playerRigidBody.AddForce(-direction * power, ForceMode2D.Force);
        }
    }

    protected override float CalculatePower(float distance, float time)
    {
        return _pullModifier * math.sqrt(math.max(time, 1) * math.max(distance, 1));
    }

    private Boolean IsNearPlayer(Vector3 position)
    {
        return Vector3.Distance(position, _playerRigidBody.position) <= _minimumDistanceFromPlayer;
    }
}