using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;

    private Rigidbody2D _rb;
    private float horizontalMovement;
    private float verticalMovement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (!_rb) Debug.LogError($"Nessuna componente RigidBody2D trovata per l'oggetto {gameObject.name}!!");
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(horizontalMovement, verticalMovement);
        if(direction.sqrMagnitude > 1) direction /= direction.magnitude;

        _rb.MovePosition(_rb.position + direction * (_speed * Time.fixedDeltaTime));
    }
}
