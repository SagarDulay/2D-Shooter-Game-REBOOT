
using UnityEngine;


[CreateAssetMenu(menuName = "Burst Weapon")]


public class BurstWeapon : RangedWeapon
{

    [SerializeField] private int bulletCount = 5;
    [SerializeField] private float delayBetweenBullets = 0.1f;


    public override void Use(Transform muzzle)
    {

        if (audioManagerReference == null)       
            audioManagerReference = FindAnyObjectByType<AudioManager>();

        MonoBehaviour runner = muzzle.GetComponentInParent<MonoBehaviour>();
        runner.StartCoroutine(ShootBurst(muzzle));

    }


        private System.Collections.IEnumerator ShootBurst(Transform muzzle)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Bullet clonedProjectile = GameObject.Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);

            clonedProjectile.damage = damage;

            audioManagerReference.PlayShootingSound(shootingSound);

            yield return new UnityEngine.WaitForSeconds(delayBetweenBullets);
        }
    }




}
