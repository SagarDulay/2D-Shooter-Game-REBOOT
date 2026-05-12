using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbodyModule;
    [SerializeField] private float bulletSpeed;

    public float damage;
    public bool isEnemyBullet;


    void Start()
    {
        rigidbodyModule.linearVelocity = transform.up * bulletSpeed;
        Destroy(gameObject, 6);
    }

    private void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.rigidbody)
        {
            if (!isEnemyBullet && collison.rigidbody.CompareTag("Enemy"))
            {
                collison.rigidbody.GetComponent<Character>().healthModule.DecreaseHealth(damage);
            }

            else if (isEnemyBullet && collison.rigidbody.CompareTag("Player"))
            {
                Character character = collison.rigidbody.GetComponent<Character>();
                Player player = character as Player;

                if(player != null && player.InvincibleOn())
                {
                    Destroy(gameObject);
                    return;
                }

                character.healthModule.DecreaseHealth(damage);

            }

            else if (isEnemyBullet && collison.rigidbody.CompareTag("Enemy"))
            {
                return;
            }

        }

        Destroy(gameObject);
    }
}
