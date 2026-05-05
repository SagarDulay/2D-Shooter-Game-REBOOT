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

    void Start()
    {
        killsForWeaponDrop = Random.Range(15, 26);
        killsForHealthDrop = Random.Range(10, 16);
    }

    public void OnEnemyKilled(Vector2 position)
    {
        killCount++;

        if (killCount >= killsForWeaponDrop)
        {
            int randomIndex = Random.Range(0, weaponPickUp.Length);
            PickUp spawnedWeapon = Instantiate(weaponPickUp[randomIndex], position, Quaternion.identity);
            Destroy(spawnedWeapon.gameObject, weaponPickupLifetime);
            killsForWeaponDrop = killCount + Random.Range(15, 26);
        }

        if (killCount >= killsForHealthDrop)
        {
            int randomIndex = Random.Range(0, pickupsToSpawn.Length);
            PickUp spawnedHealth = Instantiate(pickupsToSpawn[randomIndex], position, Quaternion.identity);
            Destroy(spawnedHealth.gameObject, healthPickupLifetime);
            killsForHealthDrop = killCount + Random.Range(10, 16);
        }
    }
}
