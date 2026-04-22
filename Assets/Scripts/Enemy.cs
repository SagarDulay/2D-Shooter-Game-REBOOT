using UnityEngine;

public class Enemy : Character
{
    private Transform playerTargetTransform;



    protected override void Start()
    {
        base.Start();
        playerTargetTransform = FindAnyObjectByType<Player>().transform;
    }

    protected virtual void Update()
    {
        movementDirection = playerTargetTransform.position - transform.position;
        movementDirection = movementDirection.normalized;

        transform.up = movementDirection;
        Move();
    }
}
