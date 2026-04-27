using UnityEngine;

public abstract class Weapon : ScriptableObject
{
    [SerializeField] protected float damage;

    public abstract void Use(Transform muzzle);

    public float GetDamageValue()
    {
        return damage;
    }

}
