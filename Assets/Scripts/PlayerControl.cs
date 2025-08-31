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

    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
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

}
