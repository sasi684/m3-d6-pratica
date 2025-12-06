using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private int _damage = 50;
    [SerializeField] private Rigidbody2D _rb;

    private Vector2 _direction;

    public float Speed { get => _speed; set => _speed = value; }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void SetBullet(Vector2 direction)
    {
        _direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            LifeController enemyHp = collision.gameObject.GetComponent<LifeController>();
            enemyHp.AddHp(-_damage);
        }
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
    }
}
