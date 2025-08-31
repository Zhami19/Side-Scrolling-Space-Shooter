using System.Collections.Generic;
using UnityEngine;

public class LaserPool : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private int poolSize = 50;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.SetActive(false);
            pool.Enqueue(laser);
        }
    }

    public GameObject GetLaser(GameObject player)
    {
        GameObject laser = pool.Dequeue();
        laser.SetActive(true);
        laser.transform.position = player.transform.position;
        return laser;
    }


    public void ReturnLaser(GameObject laser)
    {
        laser.SetActive(false);
        pool.Enqueue(laser);
    }
}