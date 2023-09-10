using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyBase
{
    Rigidbody _rb;
    PlayerController _playerController;
    ObjectPool _objectPool;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerController = FindObjectOfType<PlayerController>();
        _objectPool = FindObjectOfType<ObjectPool>();
        //à»â∫ÅAâºÇ≈íeÇî≠éÀÇµÇƒÇ›ÇÈ
        for (int i = 0; i < 10; i++)
        {
            _objectPool.GetBullet(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTransform = _playerController.transform.position;
        //transform.position = new Vector3(-25f, playerTransform.y, playerTransform.z);
    }
}
