using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BulletGeneratior : MonoBehaviour
{
    [SerializeField, Header("x���̍ŏ��p�x")] float _xMin;
    [SerializeField, Header("x���̍ő�p�x")] float _xMax;
    [SerializeField, Header("y���̍ŏ��p�x")] float _yMin;
    [SerializeField, Header("y���̍ő�p�x")] float _yMax;
    [SerializeField, Header("z���̍ŏ��p�x")] float _zMin;
    [SerializeField, Header("z���̍ő�p�x")] float _zMax;

    [SerializeField, Header("�e�����܂ł̃��~�b�g�^�C��")] float _timeRimit;
    float _currentTime; //���݂̎���

    [SerializeField, Header("�ǂ̒e��")] private BulletState _bulletState = BulletState.normal;
    ObjectPool _objectPool;
    GoogleSheetsReader _googleSheetsReader;

    private void Start()
    {
        _objectPool = FindObjectOfType<ObjectPool>();
        _googleSheetsReader = FindObjectOfType<GoogleSheetsReader>();
    }
    private void Update()
    {
        if(_googleSheetsReader.IsDataLoading())
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeRimit)
            {
                if (_bulletState == BulletState.normal)
                {
                    var bullet = _objectPool.GetBullet(transform.position, _objectPool._objectNormalPool);
                    GeneratiorRotation();
                    bullet.GetComponent<BulletDataBase>().Set(transform.forward);
                    Vector3 bulletDirection = -transform.forward;
                }
                else if (_bulletState == BulletState.special)
                {
                    var bullet = _objectPool.GetBullet(transform.position, _objectPool._objectSpecialPool);
                    GeneratiorRotation();
                    bullet.GetComponent<BulletDataBase>().Set(transform.forward);
                    Vector3 bulletDirection = transform.forward;
                }
                else
                {
                    var bullet = _objectPool.GetBullet(transform.position, _objectPool._objectRicochetPool);
                    GeneratiorRotation();
                    bullet.GetComponent<BulletDataBase>().Set(transform.forward);
                    Vector3 bulletDirection = transform.forward;
                }
                //GenerateBullet();
                _currentTime = 0;
            }
        }
    }
    public void GeneratiorRotation()
    {
        float xAngle = Random.Range(_xMin, _xMax);
        float yAngle = Random.Range(_yMin, _yMax);
        float zAngle = Random.Range(_zMin, _zMax);
        Quaternion angle = Quaternion.Euler(xAngle, yAngle, zAngle);
        transform.rotation = angle;
    }

    //protected abstract void GenerateBullet();
}
public enum BulletState
{
    normal,
    special,
    ricochet,
}
