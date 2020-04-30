using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)] [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    [SerializeField] int spawnedEnemies = 0;
    [SerializeField] TextMeshProUGUI spawnedEnemiesText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemiesText.text = spawnedEnemies.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever WHY
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;

            AddScore();

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        spawnedEnemies++;
        spawnedEnemiesText.text = spawnedEnemies.ToString();
    }

}
