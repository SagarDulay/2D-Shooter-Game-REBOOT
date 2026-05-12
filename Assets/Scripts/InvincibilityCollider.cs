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
        if (!collision.gameObject.CompareTag("Enemy")) return;       

        if (!player.InvincibleOn())
        {      
            return;
        }

        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy == null)
        {
            enemy = collision.GetComponentInParent<Enemy>();
        }

        if (enemy != null)
        {
            enemy.healthModule.DecreaseHealth(99999f);
            return;
        }

    }
}
