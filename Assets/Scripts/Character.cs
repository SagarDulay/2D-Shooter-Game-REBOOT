using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected Vector2 movementDirection;
    protected bool isDead;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rigidbodyModule;

    public Health healthModule;



    protected virtual void Start()
    {
        healthModule = new Health(100);

    }

    public void Move()
    {
        rigidbodyModule.AddForce(movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    public void Rotate(Vector3 rotationTarget)
    {
        transform.up = rotationTarget - transform.position;
    }
    
    public virtual void Attack()
    {
       
    }











}
