using System;
using UnityEngine;

public class InvinciblePickup : PickUp
{
    [SerializeField] private float invincibilityDuration = 13f;

    protected override void CollectPickUp(Character reciever)
    {
        Player player = reciever as Player;

        if (player != null )
        {
            player.ActivateInvincibility( invincibilityDuration );
        }

        base.CollectPickUp(reciever);
    }
}
