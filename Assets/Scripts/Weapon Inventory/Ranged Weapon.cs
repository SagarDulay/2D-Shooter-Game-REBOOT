using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]

public class RangedWeapon : Weapon
{
    [SerializeField] private Bullet projectilePrefab;
    [SerializeField] private float fireRate;

    [SerializeField] private AudioClip shootingSound;

    private AudioManager audioManagerReference;


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
