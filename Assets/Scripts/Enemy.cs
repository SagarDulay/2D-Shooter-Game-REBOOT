using UnityEngine;

public class Enemy : Character
{
    protected Player playerTargetTransform;
    [SerializeField] protected float distanceToAttack;
    [SerializeField] private GameObject dieEffectPrefab;

    [SerializeField] private float startingHealth = 100f;

    [SerializeField] protected GameObject tokenPrefab;
    


    protected override void Start()
    {
        base.Start();
        healthModule = new Health(startingHealth);
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
        if (tokenPrefab != null)
        {
            GameObject token = Instantiate (tokenPrefab, transform.position, Quaternion.identity);
            Destroy(token, 7f);
        }

        FindAnyObjectByType<GameManager>().EnemyKilled(this);
        Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
