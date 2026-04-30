using UnityEngine;

[CreateAssetMenu(menuName = "Ranged Weapon")]

public class RangedWeapon : Weapon
{
    [SerializeField] protected Bullet projectilePrefab;
    [SerializeField] protected float fireRate;

    [SerializeField] protected AudioClip shootingSound;
    protected AudioManager audioManagerReference;


    public override void Use(Transform muzzle)
    {

        Bullet clonedProjectile = GameObject.Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        clonedProjectile.damage = damage;

        if (audioManagerReference == null)
        {
            audioManagerReference = FindAnyObjectByType<AudioManager>();
        }

        audioManagerReference.PlayShootingSound(shootingSound);
    }

    public float GetFireRate()
    {
        return fireRate;
    }
    
}
