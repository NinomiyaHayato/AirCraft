using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletDataBase
{
    Rigidbody _rb;
    GoogleSheetsReader _googleSheetRender;
    [SerializeField, Header("スピード")] int _speed = 0;
    private void Start()
    {
        _googleSheetRender = FindObjectOfType<GoogleSheetsReader>();
        if(_googleSheetRender.IsDataLoading())
        {
            _rb = GetComponent<Rigidbody>();

            _speed = BulletSpeed(_searchNum);
        }
    }
    private void Update()
    {
        _rb.velocity = Vector3.forward * _speed;
    }
}
