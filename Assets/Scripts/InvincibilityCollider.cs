using UnityEngine;


public class InvincibilityCollider : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player.InvincibleOn()) return;

        Enemy enemy = collision.attachedRigidbody?.GetComponent<Enemy>();

        if (enemy != null)
        {
            FindAnyObjectByType<GameManager>().EnemyKilled(enemy);
            Destroy(enemy.gameObject);
        }
    }
}