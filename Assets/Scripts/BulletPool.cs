using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 100;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        //Creates pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.name = "bullet " + i.ToString();
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(GameObject enemy)
    {
        Debug.Log("Spawn Bullet; pool size: " + pool.Count);
        GameObject bullet = pool.Dequeue();
        bullet.transform.position = enemy.transform.position;
        bullet.SetActive(true);

        bullet.GetComponent<Bullet>().InitializeBullet();

        Debug.Log("GetBullet End");
        return bullet;
    }


    public void ReturnBullet(GameObject bullet)
    {
        Debug.Log("ReturnBullet Begin");
        bullet.SetActive(false);
        pool.Enqueue(bullet);
        Debug.Log("Bullet returned; pool size: " + pool.Count);
    }
}
