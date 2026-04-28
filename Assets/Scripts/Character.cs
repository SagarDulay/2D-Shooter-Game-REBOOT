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
        Vector3 destinationRotation = rotationTarget - transform.position;

        transform.up = Vector3.Lerp(transform.up, destinationRotation, Time.deltaTime * 5f);


    }
    
    public virtual void Attack()
    {
       
    }











}
