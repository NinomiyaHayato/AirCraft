using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircluBullet : MonoBehaviour
{
    [SerializeField, Header("一秒あたりの回転速度")] float _rotationSpeed = 90f;
    [SerializeField, Header("弾の速度")] float _bulletSpeed = 5f;

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
        // 弾の位置を円形の軌道に沿って更新
        _angle += _rotationSpeed * Time.deltaTime;
        float radians = _angle * Mathf.Deg2Rad;

        // 弾の新しい位置を計算
        float x = Mathf.Cos(radians) * _bulletSpeed;
        float y = Mathf.Sin(radians) * _bulletSpeed;
        _rb.velocity = transform.right * _bulletSpeed;
    }
}