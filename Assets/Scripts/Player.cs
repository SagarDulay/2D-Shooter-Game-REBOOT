using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    private Weapon currentWeapon;
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
            currentWeapon.Use();
        }
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
