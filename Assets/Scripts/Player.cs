using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Transform weaponMuzzle;
     


    protected override void Start()
    {

        base.Start();
        healthModule.OnHealthZero += EndGame;
    } 

    private void EndGame()
    {
        FindAnyObjectByType<GameManager>().RegisterHighScore();
        Destroy(gameObject);
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
        currentWeapon.Use(weaponMuzzle);
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
