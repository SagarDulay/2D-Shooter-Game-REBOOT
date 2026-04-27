using UnityEngine;

public class Enemy : Character
{
    private Transform playerTargetTransform;



    protected override void Start()
    {
        base.Start();
        playerTargetTransform = FindAnyObjectByType<Player>().transform;
        healthModule.OnHealthZero += Die;
    }

    protected virtual void Update()
    {
        movementDirection = playerTargetTransform.position - transform.position;
        movementDirection = movementDirection.normalized;

        Rotate(playerTargetTransform.position);

        Move();
    }

    private void Die()
    {
        FindAnyObjectByType<GameManager>().EnemyKilled(this);
        Destroy(gameObject);
    }
}
