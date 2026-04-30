using UnityEngine;

public class Enemy : Character
{
    protected Player playerTargetTransform;
    [SerializeField] protected float distanceToAttack;
    [SerializeField] private GameObject dieEffectPrefab;


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


        if(Vector2.Distance(transform.position, playerTargetTransform.transform.position) < distanceToAttack)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }

    public override void Attack()
    {
        base.Attack();

        playerTargetTransform.healthModule.DecreaseHealth(Time.deltaTime);
    }
    protected void Die()
    {
        FindAnyObjectByType<GameManager>().EnemyKilled(this);
        Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
