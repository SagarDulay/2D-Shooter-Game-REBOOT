using Unity.VisualScripting;
using UnityEngine;

public class ShootingEnemy : Enemy



{

    [SerializeField] protected Weapon currentWeapon;
    [SerializeField] protected Transform weaponMuzzle;
    public bool canShoot;



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
