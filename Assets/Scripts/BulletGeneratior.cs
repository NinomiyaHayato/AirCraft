using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGeneratior : MonoBehaviour
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

    public BulletState BulletState
    {
        get => _bulletState;
        set
        {
            _bulletState = value;
        }
    }
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
                GeneratiorRotation();
                if (BulletState == BulletState.normal)
                {
                    _objectPool.GetBullet(transform.position, _objectPool._objectNormalPool);
                }
                else if (BulletState == BulletState.special)
                {
                    _objectPool.GetBullet(transform.position, _objectPool._objectSpecialPool);
                }
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
}
public enum BulletState
{
    normal,
    special,
}
