using UnityEngine;

public abstract class Weapon
{
    [SerializeField] protected float damage;

    public abstract void Use();

    public float GetDamageValue()
    {
        return damage;
    }

}
