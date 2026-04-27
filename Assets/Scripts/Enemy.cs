using UnityEngine;

public class Enemy : Character
{
    private Player playerTargetTransform;



    protected override void Start()
    {
        base.Start();
        playerTargetTransform = FindAnyObjectByType<Player>();
        healthModule.OnHealthZero += Die;
    }

    protected virtual void Update()
    {
        if(playerTargetTransform == null)
        {
            return;
        }
        
        movementDirection = playerTargetTransform.transform.position - transform.position;
        movementDirection = movementDirection.normalized;

        Rotate(playerTargetTransform.transform.position);

        Move();

        if(Vector2.Distance(transform.position, playerTargetTransform.transform.position) < 2f)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        base.Attack();

        playerTargetTransform.healthModule.DecreaseHealth(Time.deltaTime);
    }
    private void Die()
    {
        FindAnyObjectByType<GameManager>().EnemyKilled(this);
        Destroy(gameObject);
    }
}
