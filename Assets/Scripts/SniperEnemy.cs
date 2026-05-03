using UnityEngine;

public class SniperEnemy : ShootingEnemy
{
    [SerializeField] private float spotRange;
    [SerializeField] private float shootingRange;

    private SniperWeapon GetSniperWeapon()
    {
        return currentWeapon as SniperWeapon;
    }

    protected override void Start()
    {
        base.Start();
        canShoot = true;
    }

    protected override void Update()
    {
        if (playerTargetTransform == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerTargetTransform.transform.position);

        Rotate(playerTargetTransform.transform.position);

        if (distanceToPlayer > shootingRange)
        {
            movementDirection = (playerTargetTransform.transform.position - transform.position).normalized;
            Move();
        }

        if (distanceToPlayer <= spotRange && distanceToPlayer <= distanceToAttack)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        if (canShoot && GetSniperWeapon() != null)
        {
            GetSniperWeapon().Use(weaponMuzzle);
            canShoot = false;
            Invoke("CanShootAgain", GetSniperWeapon().GetFireRate());
        }
    }
}