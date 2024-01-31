using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletDataBase,IPause
{
    Rigidbody _rb;
    GoogleSheetsReader _googleSheetRender;
    BulletGeneratior _bulletGenaratior;
    Vector3 _direction;

    [SerializeField, Header("åüçıÇµÇΩÇ¢No")] int _searchNum;


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
        
    }

    public override void Hit()
    {
        gameObject.SetActive(false);
    }

    public void Pause()
    {
        _rb.velocity = transform.forward * 0.5f;
    }

    public void Resume()
    {

        _rb.velocity = transform.forward * _speed * 1.5f;
    }
}
