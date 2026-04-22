using UnityEngine;

public class Player : Character, IDash
{
    [SerializeField] private Vector2 mousePosition;
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.up = (Vector3)mousePosition - transform.position;

        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {

            Dash();
        }
    }

    public void Dash()
    {
        rigidbodyModule.AddForce(movementDirection * moveSpeed * 5f);
    }
    
}
