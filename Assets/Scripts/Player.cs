using UnityEngine;

public class Player : Character
{
    void Update()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
        Move();
    }

    public override void Dash()
    {

    }
    
}
