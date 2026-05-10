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
    [SerializeField] private PickupSpawner pickupSpawner;
    private float scoreTimer;
    private int pointsPerKill = 10;




    void Start()
    {
        StartCoroutine( SpawnRandomEnemy() );
   
    }

    private void Update()
    {
        scoreTimer += Time.deltaTime;

        if (scoreTimer >= 20f)
        {
            pointsPerKill += 10;
            scoreTimer = 0f;
        }
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
        currentScore += pointsPerKill;
        pickupSpawner.OnEnemyKilled(deadEnemy.transform.position);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddToScore(int amount)
    {
        currentScore += amount;
    }


    public void RegisterHighScore()
    {
        if (currentScore > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", currentScore);
        }
        
    }

}
