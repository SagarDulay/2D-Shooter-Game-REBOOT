using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [Header("Health Drops")]
    [SerializeField] private PickUp[] pickupsToSpawn;
    [SerializeField] private float healthPickupLifetime = 5f;

    [Space(20)]

    [Header("Weapon Drops")]
    [SerializeField] private PickUp[] weaponPickUp;
    [SerializeField] private float weaponPickupLifetime = 8f;

    private int killCount;
    private int killsForWeaponDrop;
    private int killsForHealthDrop;

    [Space(20)]

    [Header("Invincibility Drops")]
    [SerializeField] private PickUp invincibilityPickUp;
    [SerializeField] private float invincibilityPickupLifetime = 5f;

    private int killsForInvincibilityDrop;

    void Start()
    {
        killsForInvincibilityDrop = Random.Range(20, 35);
        killsForWeaponDrop = Random.Range(10, 23);
        killsForHealthDrop = Random.Range(7, 16);
    }

    public void OnEnemyKilled(Vector2 position)
    {
        killCount++;

        if (killCount >= killsForWeaponDrop)
        {
            int randomIndex = Random.Range(0, weaponPickUp.Length);
            PickUp spawnedWeapon = Instantiate(weaponPickUp[randomIndex], GetRandomScreenPosition(), Quaternion.identity);
            Destroy(spawnedWeapon.gameObject, weaponPickupLifetime);
            killsForWeaponDrop = killCount + Random.Range(15, 26);
        }

        if (killCount >= killsForHealthDrop)
        {
            int randomIndex = Random.Range(0, pickupsToSpawn.Length);
            PickUp spawnedHealth = Instantiate(pickupsToSpawn[randomIndex], GetRandomScreenPosition(), Quaternion.identity);
            Destroy(spawnedHealth.gameObject, healthPickupLifetime);
            killsForHealthDrop = killCount + Random.Range(10, 16);
        }

        if (killCount >= killsForInvincibilityDrop)
        {
            PickUp spawnedInvincibility = Instantiate(invincibilityPickUp, GetRandomScreenPosition(), Quaternion.identity);
            Destroy(spawnedInvincibility.gameObject, invincibilityPickupLifetime);
            killsForInvincibilityDrop = killCount + Random.Range(20, 35);
        }
    }

    private Vector2 GetRandomScreenPosition()
    {
        Camera cam = Camera.main;
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float randomX = Random.Range(-camWidth, camWidth);
        float randomY = Random.Range(-camHeight, camHeight);

        return new Vector2 (randomX, randomY);
    }
}
