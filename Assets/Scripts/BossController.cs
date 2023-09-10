using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyBase
{
    Rigidbody _rb;
    PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTransform = _playerController.transform.position;
        transform.position = new Vector3(-25f, playerTransform.y, playerTransform.z);
    }
}
