using System;
using Unity.VisualScripting;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate;
    
    public override void Use()
    {
        Debug.Log("Gra ta ta ta");
    }

    public float GetFireRate()
    {
        return fireRate;
    }
    
    public RangedWeapon(float newFireRate, float newDamage)
    {
        fireRate = newFireRate;
        damage = newDamage;
    }

    
}
