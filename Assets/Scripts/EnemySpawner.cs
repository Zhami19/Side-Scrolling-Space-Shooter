using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;

    private void Start()
    {
        //enemyPool = EnemyPool.FindAnyObjectByType<EnemyPool>();
        StartCoroutine(SpawnEnemies());
    }


    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.5f, 2.5f));
            enemyPool.GetEnemy();
        }
    }
}
