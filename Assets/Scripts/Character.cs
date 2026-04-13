using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    public Vector2 movementDirection;

    private bool isDead;
    
    public Rigidbody2D rigidbodyModule;
    public Health healthModule;



    public virtual void Start()
    {
        healthModule = new Health(100);

    }

    public void Move()
    {
        rigidbodyModule.AddForce(movementDirection * moveSpeed * Time.fixedDeltaTime);
    }


    public void Dash()
    {

    }


    public virtual void Attack()
    {
       
    }











}
