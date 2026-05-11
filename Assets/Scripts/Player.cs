using System.Collections;
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
    private bool invincibleOn;
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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

    public float GetWeaponTimer()
    {
        return weaponTimer;
    }

    public string GetCurrentWeaponName()
    {
        return currentWeapon.name;
    }

    public void ActivateInvincibility(float invincibilityDuration)
    {
        if (invincibleOn) return;
        StartCoroutine(InvincibilityCorountine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCorountine(float invincibilityDuration)
    {
        invincibleOn = true;
        spriteRenderer.color = Color.black;

        yield return new WaitForSeconds(invincibilityDuration);

        invincibleOn = false;
        spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (!invincibleOn) return;

        Enemy enemy = collision.attachedRigidbody?.GetComponent<Enemy>();

        if (enemy != null)
        {
            FindAnyObjectByType<GameManager>().EnemyKilled(enemy);
            Destroy(enemy.gameObject);
        }
    }

    public bool InvincibleOn()
    {
        return invincibleOn;
    }

}