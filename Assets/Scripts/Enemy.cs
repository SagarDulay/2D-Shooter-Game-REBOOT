using UnityEngine;

public class Enemy : Character
{
    public Transform playerTargetTransform;



    public override void Start()
    {
        base.Start();
        playerTargetTransform = FindAnyObjectByType<Player>().transform;
    }

    public virtual void Update()
    {
        movementDirection = playerTargetTransform.position - transform.position;
        movementDirection = movementDirection.normalized;
        Move();
    }
}
