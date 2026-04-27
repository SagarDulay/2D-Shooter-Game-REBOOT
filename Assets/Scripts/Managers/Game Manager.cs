using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour

{

    [SerializeField] private List<Enemy> allSpawnedEnemies;

    [SerializeField] private Enemy[] possibleEnemyPrefabs;
    [SerializeField] private Transform[] possibleSpawnPoints;

    [SerializeField] private Transform enemiesParent;

    [SerializeField] private int currentScore;

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
}
