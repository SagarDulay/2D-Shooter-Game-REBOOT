using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour

{
    [Header("Spawning Enemies")]
    [SerializeField] private List<Enemy> allSpawnedEnemies;
    [SerializeField] private Enemy[] possibleEnemyPrefabs;
    [SerializeField] private Transform[] possibleSpawnPoints;
    [SerializeField] private Transform enemiesParent;

    [Space(10)] 

    [Header("Score")]
    [SerializeField] private int currentScore;

    [Space(10)]

    [Header("Pick Ups")]
    [SerializeField] private PickUp[] pickupsToSpawn;
    

    [Space(10)]

    [Header("Weapon Drops")]
    [SerializeField] private PickUp[] weaponPickupSpawn;
   



    private int killCount;
    private int killsForWeaponDrop;
    private int killsForHealthDrop;

    void Start()
    {
        StartCoroutine( SpawnRandomEnemy() );
        killsForWeaponDrop = Random.Range(15, 26);
        killsForHealthDrop = Random.Range(10, 16);

    }

    private IEnumerator SpawnRandomEnemy()
    {
        while(true) 
        {
            if (allSpawnedEnemies.Count < 15)
            {
                int amountOfIndexs = possibleEnemyPrefabs.Length;
                int randomIndex = Random.Range(0, amountOfIndexs);
                Enemy clonedEnemy = Instantiate(possibleEnemyPrefabs[randomIndex]);            

                allSpawnedEnemies.Add(clonedEnemy);

                int amountOfSpawnPoints = possibleSpawnPoints.Length;
                int randomIndexOfSpawnPoint = Random.Range(0, amountOfSpawnPoints);
                Transform randomSpawnPoint = possibleSpawnPoints[randomIndexOfSpawnPoint];

                clonedEnemy.transform.SetParent(enemiesParent);
                clonedEnemy.transform.position = randomSpawnPoint.position;
            }

            yield return new WaitForSeconds(2f);

        }

    }

    public void EnemyKilled(Enemy deadEnemy)
    {
        allSpawnedEnemies.Remove(deadEnemy);
        currentScore += 10;
        killCount++;

        if (killCount >= killsForWeaponDrop)
        {
            int randomIndex = Random.Range(0, weaponPickupSpawn.Length);
            Instantiate(weaponPickupSpawn[randomIndex], deadEnemy.transform.position, Quaternion.identity);
            killsForWeaponDrop = killCount + Random.Range(15, 26);
        }

        if (killCount >= killsForHealthDrop)
        {
            SpawnRandomPickup(deadEnemy.transform.position);
            killsForHealthDrop = killCount + Random.Range(10, 16);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void RegisterHighScore()
    {
        if (currentScore > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", currentScore);
        }
        
    }

    private void SpawnRandomPickup(Vector2 positionToSpawn)
    {
        int randomIndex = Random.Range(0, pickupsToSpawn.Length);
        PickUp randomPickup = pickupsToSpawn[randomIndex];
        Instantiate(randomPickup, positionToSpawn, Quaternion.identity);
    }
}
