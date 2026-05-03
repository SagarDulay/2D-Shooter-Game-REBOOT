using UnityEngine;

[CreateAssetMenu(menuName = "Sniper Weapon")]
public class SniperWeapon : RangedWeapon
{

    public override void Use(Transform muzzle)
    {
        if (audioManagerReference == null)
            audioManagerReference = FindAnyObjectByType<AudioManager>();

        Bullet clonedProjectile = GameObject.Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        clonedProjectile.damage = damage;

        audioManagerReference.PlayShootingSound(shootingSound);
    }

    public override float GetFireRate()
    {
        return fireRate;
    }
}
