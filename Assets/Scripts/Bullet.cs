using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletPool bulletPool;

    private GameObject target;
    private float speed = 1f;
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

}
