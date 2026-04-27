using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]

public class RangedWeapon : Weapon
{
    [SerializeField] private Bullet projectilePrefab;
    [SerializeField] private float fireRate;
    
    public override void Use(Transform muzzle)
    {
        
        Bullet clonedProjectile = GameObject.Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        clonedProjectile.damage = damage;
    }

    public float GetFireRate()
    {
        return fireRate;
    }
    
}
