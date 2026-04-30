using System.Collections;
using UnityEngine;

public class MachineGunEnemy : ShootingEnemy
{
    [SerializeField] private int bulletCount = 5;
    [SerializeField] private float delayBetweenBullets = 0.1f;


    public override void Attack()
    {
        if (!canShoot) return;

        canShoot = false;

        StartCoroutine(ShootBurst());
    }

    private IEnumerator ShootBurst()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            currentWeapon.Use(weaponMuzzle);

            yield return new WaitForSeconds(delayBetweenBullets);
        }

        Invoke("CanShootAgain", 1.5f);
    }
}



