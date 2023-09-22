using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircluBullet : MonoBehaviour
{
    [SerializeField, Header("ˆê•b‚ ‚½‚è‚Ì‰ñ“]‘¬“x")] float _rotationSpeed = 90f;
    [SerializeField, Header("’e‚Ì‘¬“x")] float _bulletSpeed = 5f;

    private float _angle = 0f;
    PlayerController _playerController;
    Rigidbody _rb;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // ’e‚ÌˆÊ’u‚ğ‰~Œ`‚Ì‹O“¹‚É‰ˆ‚Á‚ÄXV
        _angle += _rotationSpeed * Time.deltaTime;
        float radians = _angle * Mathf.Deg2Rad;

        // ’e‚ÌV‚µ‚¢ˆÊ’u‚ğŒvZ
        float x = Mathf.Cos(radians) * _bulletSpeed;
        float y = Mathf.Sin(radians) * _bulletSpeed;
        _rb.velocity = transform.right * _bulletSpeed;
    }
}