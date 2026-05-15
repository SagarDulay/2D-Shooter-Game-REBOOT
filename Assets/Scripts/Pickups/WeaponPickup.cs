using UnityEngine;

public class WeaponPickUp : PickUp
{
    [SerializeField] private Weapon weaponToGive;

    protected override void CollectPickUp(Character receiver)
    {
        Player player = receiver as Player;

        if (player != null && weaponToGive != null)
        {
            player.EquipWeapon(weaponToGive);
        }

        base.CollectPickUp(receiver);
    }
}
