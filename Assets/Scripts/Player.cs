using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    [SerializeField] private Weapon currentWeapon;
    [SerializeField] private Transform weaponMuzzle;
    [SerializeField] private float shootCountdown;
    [SerializeField] private float weaponPickupDuration = 11f;

    private Weapon defaultWeapon;
    private float weaponTimer;

   protected override void Start()
    {
        base.Start();
        defaultWeapon = currentWeapon;
        healthModule.OnHealthZero += EndGame;
    }

    private void EndGame()
    {
        FindAnyObjectByType<GameManager>().RegisterHighScore();
        FindAnyObjectByType<UIManager>().ShowGameOver();
        Destroy(gameObject);
    }

    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Rotate(mousePosition);
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        shootCountdown -= Time.deltaTime;

        if (shootCountdown <= 0f)
        {
            if (Input.GetMouseButton(0))
            {
                Attack();
            }
        }



        if (weaponTimer > 0 )
        {
            weaponTimer -= Time.deltaTime;

            if (weaponTimer <= 0f )
            {
                currentWeapon = defaultWeapon;
            }
        }
    }

    public override void Attack()
    {
        base.Attack();

        if (currentWeapon is RangedWeapon currentRangedWeapon)
        {
            shootCountdown = currentRangedWeapon.GetFireRate();
        }
        else
        {
            shootCountdown = 1;
        }

        currentWeapon.Use(weaponMuzzle);
    }

    public void Dash()
    {
        rigidbodyModule.AddForce(movementDirection * moveSpeed * 5f);
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
        weaponTimer = weaponPickupDuration;
    }
}