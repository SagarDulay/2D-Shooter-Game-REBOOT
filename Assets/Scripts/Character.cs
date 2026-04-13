using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed;
    public bool isDead;

    public Rigidbody2D rigidbodyModule;
    public Health healthModule;



    void Start()
    {
        healthModule = new Health(100);

        healthModule.IncreaseHealth(5.5f);
        Debug.Log(healthModule.healthPoints);
        healthModule.DecreaseHealth(25.2f);
        Debug.Log(healthModule.healthPoints);
    }

    public void Move()
    {

    }


    public void Dash()
    {

    }
    

    public void Attack()
    {

    }











}
