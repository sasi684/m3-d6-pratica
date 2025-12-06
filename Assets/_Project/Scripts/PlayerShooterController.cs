using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float _fireRange = 10f;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioClip _bulletShoot;

    private PlayerController _player;
    private AudioSource _audioSource;
    private float lastShot = 0;

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
        _audioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (Time.time - lastShot > _fireRate) Shoot();
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = _fireRange;
        
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(enemy.transform.position, _player.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;

    }

    void Shoot()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _player.transform.position;
            Vector2 direction = nearestEnemy.transform.position - bullet.transform.position;
            direction.Normalize();
            _audioSource.clip = _bulletShoot;
            _audioSource.Play();
            bullet.SetBullet(direction);
            lastShot = Time.time;
        }
    }
}
