using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] LaserPool laserPool;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private Vector2 _moveDirection;

    public InputActionReference move;
    public InputActionReference shoot;

    private float lastTimeFired = 0;

    public UnityEvent OnDeath;

    private void Start()
    {
        transform.position = new Vector2(0, 0);
    }

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        Borders();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }

    private void OnEnable()
    {
        shoot.action.started += Shoot;
    }

    private void OnDisable()
    {
        shoot.action.started -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        if (Time.time - lastTimeFired > 1f) //Cooldown
        {
            laserPool.GetLaser(this.gameObject);
            lastTimeFired = Time.time;
        }
    }

    private void Borders()
    {
        Vector3 pos = transform.position;

        if (pos.y >= 5.7f)
        {
            pos.y = -5.7f;
        }
        else if (pos.y <= -5.7f)
        {
            pos.y = 5.7f;
        }

        pos.x = Mathf.Clamp(pos.x, -10f, 10f);
        transform.position = pos;
    }

}
