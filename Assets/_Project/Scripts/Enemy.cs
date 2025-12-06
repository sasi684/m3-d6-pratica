using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private AudioClip _destroy;

    private AudioSource _audioSource;

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = GetComponentInChildren<AudioSource>();
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
        if(collision.gameObject.CompareTag("Player"))
            Destroy(collision.gameObject);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            LifeController enemyHp = GetComponent<LifeController>();
            if (!enemyHp || enemyHp.GetHp() <= 0)
            {
                _audioSource.clip = _destroy;
                _audioSource.Play();
                Destroy(gameObject, _destroy.length);
            }
        }
    }
}
