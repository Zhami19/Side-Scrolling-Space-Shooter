using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private Vector2 _moveDirection;

    public InputActionReference move;
    public InputActionReference shoot;

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
        Debug.Log("Shot");
    }
}
