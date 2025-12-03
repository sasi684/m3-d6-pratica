using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private Rigidbody2D _rb;
    private GameObject _player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_player) EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
            Destroy(collision.gameObject);
    }
}
