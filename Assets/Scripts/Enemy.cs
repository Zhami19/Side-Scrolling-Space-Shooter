using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;


public class Enemy : MonoBehaviour
{
    private UI ui;
    private PlayerControl playerControl;
    private EnemyPool enemyPool;
    private BulletPool bulletPool;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float _frequency;
    [SerializeField] private float _distance;

    [SerializeField] Vector3 _position;
    [SerializeField] float sinCenterY;

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] private float waitTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        ui = UI.FindFirstObjectByType<UI>();
        playerControl = PlayerControl.FindAnyObjectByType<PlayerControl>();
        bulletPool = BulletPool.FindAnyObjectByType<BulletPool>();
        enemyPool = EnemyPool.FindAnyObjectByType<EnemyPool>();

        //playerControl.OnDeath.AddListener(ui.YouLose);
    }

    public void InitializeEnemy()
    {
        sinCenterY = transform.position.y;

        StartCoroutine(ShootBullet());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        _position = transform.position;
        float _sin = Mathf.Sin(_position.x * _frequency) * _distance;
        _position.y = sinCenterY + _sin;

        _position.x -= moveSpeed * Time.deltaTime;
        transform.Rotate(0, .5f, 0);
        transform.position = _position;
    }

    private IEnumerator ShootBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            bulletPool.GetBullet(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        enemyPool.ReturnEnemy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            playerControl.OnDeath.Invoke();
            enemyPool.ReturnEnemy(this.gameObject);
        }
    }
}
