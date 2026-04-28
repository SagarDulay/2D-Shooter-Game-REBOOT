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
    [SerializeField] private float chanceToSpawnPickup;

    void Start()
    {
        StartCoroutine( SpawnRandomEnemy() );
   
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

    void Update()
    {

    }

    public void EnemyKilled(Enemy deadEnemy)
    {
        allSpawnedEnemies.Remove(deadEnemy);
        currentScore += 10;

        if (Random.Range(0, 100) < chanceToSpawnPickup)
        {
            SpawnRandomPickup(deadEnemy.transform.position);
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
