using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemy : Enemy
{

    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Transform weaponMuzzle;
    [SerializeField] 
    private bool canShoot;



    public override void Attack()
    {
        if (canShoot)
        {
            currentWeapon.Use(weaponMuzzle);
            canShoot = false;
            Invoke("CanShootAgain", 1.5f);
            base.Attack();
        }
    }

    private void CanShootAgain()
    {
        canShoot = true;
    }

    protected override void Start()
    {
        canShoot = true;
        base.Start();
        
    }

    protected override void Update()
    {
        base.Update();
    }
    
}
