using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    private Vector2 _direction;

    public float Speed { get => _speed; set => _speed = value; }

    public void SetBullet(Vector2 direction)
    {
        _direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
