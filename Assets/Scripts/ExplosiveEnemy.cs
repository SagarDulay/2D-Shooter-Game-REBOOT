using UnityEngine;

public class ExplosiveEnemy : Enemy

{
    [SerializeField] private float explosionDamage = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        playerTargetTransform.healthModule.DecreaseHealth(explosionDamage);

        Die();
    }


}
