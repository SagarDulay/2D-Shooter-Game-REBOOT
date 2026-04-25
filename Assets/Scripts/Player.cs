using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Transform weaponMuzzle;
    [SerializeField] private Bullet projectilePrefab; 

    private Weapon currentWeapon;

    protected override void Start()
    {
        currentWeapon = new RangedWeapon(
            newFireRate:10,
            newDamage:5, 
            newProjectile:projectilePrefab, 
            newMuzzle:weaponMuzzle
            );

        base.Start();
    } 
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Rotate(mousePosition);

        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {

            Dash();
        }

        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        base.Attack();
        currentWeapon.Use();
    }
    public void Dash()
    {
        rigidbodyModule.AddForce(movementDirection * moveSpeed * 5f);
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
    }
    
}
