using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private BulletPool bulletPool;

    private GameObject target;
    [SerializeField] private float speed = 1f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        bulletPool = BulletPool.FindAnyObjectByType<BulletPool>();
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.linearVelocity = new Vector2(moveDir.x, moveDir.y);
    }

    private void OnBecameInvisible()
    {
        bulletPool.ReturnBullet(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false); 
            this.gameObject.SetActive(false);
        }
    }

}
