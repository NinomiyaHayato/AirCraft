using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircluBullet : MonoBehaviour
{
    [SerializeField, Header("��b������̉�]���x")] float _rotationSpeed = 90f;
    [SerializeField, Header("�e�̑��x")] float _bulletSpeed = 5f;

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
        // �e�̈ʒu���~�`�̋O���ɉ����čX�V
        _angle += _rotationSpeed * Time.deltaTime;
        float radians = _angle * Mathf.Deg2Rad;

        // �e�̐V�����ʒu���v�Z
        float x = Mathf.Cos(radians) * _bulletSpeed;
        float y = Mathf.Sin(radians) * _bulletSpeed;
        _rb.velocity = transform.right * _bulletSpeed;
    }
}