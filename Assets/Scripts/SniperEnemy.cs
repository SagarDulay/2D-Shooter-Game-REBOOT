using UnityEngine;

public class SniperEnemy : ShootingEnemy

{ 
    [SerializeField] private float enemyDistance;

    protected override void Update()
    {
        if (playerTargetTransform == null) return;

        float distance = Vector2.Distance(transform.position, playerTargetTransform.transform.position);

        Rotate(playerTargetTransform.transform.position);


        if (distance < enemyDistance)
        {
            movementDirection = transform.position - (playerTargetTransform.transform.position).normalized;
            Move();
        }

        else if (distance < distanceToAttack)
            {
                Attack();
            }

        else
        {
            Move();
        }


    }
}
