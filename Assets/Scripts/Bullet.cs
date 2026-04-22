using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyModule;
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        rigidbodyModule.linearVelocity = transform.up * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        Destroy(gameObject);
    }
}
