using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float _frequency = 6f;
    [SerializeField] private float _distance = .75f;

    [SerializeField] Vector3 _position;
    [SerializeField] float sinCenterY;

    [SerializeField] GameObject obstaclePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sinCenterY = transform.position.y;
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
}
