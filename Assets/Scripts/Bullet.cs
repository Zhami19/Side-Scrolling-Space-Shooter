using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private UI ui;
    private BulletPool bulletPool;
    private GameObject target;
    private PlayerControl playerControl;

    [SerializeField] private float speed = 1f;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ui = UI.FindFirstObjectByType<UI>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        playerControl = target.GetComponent<PlayerControl>();
        bulletPool = BulletPool.FindAnyObjectByType<BulletPool>();

        //playerControl.OnDeath.AddListener(ui.YouLose);
    }

    public void InitializeBullet()
    {
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        rb.linearVelocity = new Vector2(moveDir.x, moveDir.y);
    }

    private void OnBecameInvisible()
    {
        Debug.Log("ReturnBullet Called");
        bulletPool.ReturnBullet(this.gameObject);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            playerControl.OnDeath.Invoke();
        }
    }
}
