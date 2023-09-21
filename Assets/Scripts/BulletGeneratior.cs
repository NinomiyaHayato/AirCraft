using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGeneratior : MonoBehaviour
{
    [SerializeField, Header("x軸の最小角度")] float _xMin;
    [SerializeField, Header("x軸の最大角度")] float _xMax;
    [SerializeField, Header("y軸の最小角度")] float _yMin;
    [SerializeField, Header("y軸の最大角度")] float _yMax;
    [SerializeField, Header("z軸の最小角度")] float _zMin;
    [SerializeField, Header("z軸の最大角度")] float _zMax;

    [SerializeField, Header("弾生成までのリミットタイム")] float _timeRimit;
    float _currentTime; //現在の時間

    [SerializeField, Header("どの弾か")] private BulletState _bulletState = BulletState.normal;
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
                if (BulletState == BulletState.normal)
                {
                    _objectPool.GetBullet(transform.position, _objectPool._objectNormalPool);
                    GeneratiorRotation();
                    Vector3 bulletDirection = -transform.forward;
                }
                else if (BulletState == BulletState.special)
                {
                    _objectPool.GetBullet(transform.position, _objectPool._objectSpecialPool);
                    GeneratiorRotation();
                    Vector3 bulletDirection = transform.forward;
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
