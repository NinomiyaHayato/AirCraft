using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletDataBase
{
    Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        int speed = BulletSpeed(_searchNum);

        _rb.velocity = Vector3.forward * speed;
    }
}
