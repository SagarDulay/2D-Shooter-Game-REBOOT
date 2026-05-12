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
    private float invincibilityTimer;
    private SpriteRenderer spriteRenderer;
    private Coroutine invincibilityCoroutine;

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
        CancelCurrentUpgrade();
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
        CancelCurrentUpgrade(); 
        invincibilityCoroutine = StartCoroutine(InvincibilityCorountine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCorountine(float invincibilityDuration)
    {
        invincibleOn = true;
        invincibilityTimer = invincibilityDuration;
        spriteRenderer.color = Color.black;

        while (invincibilityTimer > 0f)
        {
            invincibilityTimer -= Time.deltaTime;
            yield return null;
        }

        invincibleOn = false;
        invincibilityTimer = 0f;
        spriteRenderer.color = Color.white;
    }

    public bool InvincibleOn()
    {
        return invincibleOn;
    }

    public float GetInvincibilityTimer()
    {
        return invincibilityTimer;
    }

    private void CancelCurrentUpgrade()
    {
        if (invincibleOn) 
        {
            StopCoroutine(invincibilityCoroutine);
            invincibleOn = false;
            invincibilityTimer = 0f;
            spriteRenderer.color = Color.white;
        }

        if (weaponTimer > 0f) 
        {
            weaponTimer = 0f;
            currentWeapon = defaultWeapon;
        }
    }
}