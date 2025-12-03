using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        if (_player)
        {
            target = _player.transform;
            Vector3 camPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = camPosition;
        }
    }
}
