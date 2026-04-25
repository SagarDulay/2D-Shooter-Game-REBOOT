using System;
using Unity.VisualScripting;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private Bullet projectilePrefab;
    [SerializeField] private Transform weaponMuzzle;
    [SerializeField] private float fireRate;
    
    public override void Use()
    {
        
        GameObject.Instantiate(projectilePrefab, weaponMuzzle.position, weaponMuzzle.rotation);
    }

    public float GetFireRate()
    {
        return fireRate;
    }
    
    public RangedWeapon(float newFireRate, float newDamage,Bullet newProjectile, Transform newMuzzle)
    {
        projectilePrefab = newProjectile;
        weaponMuzzle = newMuzzle;
        fireRate = newFireRate;
        damage = newDamage;
    }

    
}
