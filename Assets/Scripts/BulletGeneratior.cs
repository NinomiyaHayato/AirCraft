using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGeneratior : MonoBehaviour
{
    [SerializeField, Header("xŽ²‚ÌÅ¬Šp“x")] float _xMin;
    [SerializeField, Header("xŽ²‚ÌÅ‘åŠp“x")] float _xMax;
    [SerializeField, Header("yŽ²‚ÌÅ¬Šp“x")] float _yMin;
    [SerializeField, Header("yŽ²‚ÌÅ‘åŠp“x")] float _yMax;
    [SerializeField, Header("zŽ²‚ÌÅ¬Šp“x")] float _zMin;
    [SerializeField, Header("zŽ²‚ÌÅ‘åŠp“x")] float _zMax;

    [SerializeField, Header("’e¶¬‚Ü‚Å‚ÌƒŠƒ~ƒbƒgƒ^ƒCƒ€")] float _timeRimit;
    float _currentTime; //Œ»Ý‚ÌŽžŠÔ

    [SerializeField, Header("‚Ç‚Ì’e‚©")] private BulletState _bulletState = BulletState.normal;
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
