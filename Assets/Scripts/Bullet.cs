using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyModule;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        rigidbodyModule.linearVelocity = transform.up * bulletSpeed;
        Destroy(gameObject, 6);
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.rigidbody)
        {
            if(collison.rigidbody.CompareTag("Enemy"))
            {
                collison.rigidbody.GetComponent<Enemy>().healthModule.DecreaseHealth(50);
            }
          
        }

        Destroy(gameObject);
    }
}
