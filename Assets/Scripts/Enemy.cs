using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float _frequency = 6f;
    [SerializeField] private float _distance = .75f;

    [SerializeField] Vector3 _position;
    [SerializeField] float sinCenterY;

    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] private float waitTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        transform.Rotate(0, 5f, 0);
        transform.position = _position;
    }

    private IEnumerator ShootBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(obstaclePrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}
