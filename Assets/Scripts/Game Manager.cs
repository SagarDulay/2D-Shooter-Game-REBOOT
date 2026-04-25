using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour

{

    [SerializeField] private List<Enemy> allSpawnedEnemies;

    [SerializeField] private Enemy[] possibleEnemyPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 2f, 4f);
   
    }
    private void SpawnRandomEnemy()
    {
        int amountOfIndexs = possibleEnemyPrefabs.Length;
        int randomIndex = Random.Range(0, amountOfIndexs);

        Instantiate(possibleEnemyPrefabs[randomIndex]);


    }

    void Update()
    {

    }
}
