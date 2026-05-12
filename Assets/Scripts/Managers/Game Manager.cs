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

    [Space(10)]
    [Header("Difficulty Scaling")]
    private float difficultyTimer;
    private float enemySpeedIncrease;
    private float enemyDamageIncrease;
    private float enemyHealthIncrease;
    


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

        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= 20f)
        {
            enemySpeedIncrease += 7f;
            enemyDamageIncrease += 2f;
            enemyHealthIncrease += 10f;
            difficultyTimer = 0f;
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

        Player player = FindAnyObjectByType<Player>();
        currentScore += player.InvincibleOn() ? pointsPerKill * 2 : pointsPerKill;

        pickupSpawner.OnEnemyKilled(deadEnemy.transform.position);
    }

    public void NukeAllEnemies()
    {
        List<Enemy> enemiesNuked = new List<Enemy>(allSpawnedEnemies);
        
        foreach (Enemy enemy in enemiesNuked)
        {
            if (enemy != null)
            {
                int nukeMultiplier = pointsPerKill * 2;
                currentScore += nukeMultiplier;
                enemy.healthModule.DecreaseHealth(Mathf.Infinity);
            }
        }
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


    public float GetEnemySpeedIncrease() { return enemySpeedIncrease; }
    public float GetEnemyDamageIncrease() { return enemyDamageIncrease; }
    public float GetEnemyHealthIncrease() { return enemyHealthIncrease; }

}
