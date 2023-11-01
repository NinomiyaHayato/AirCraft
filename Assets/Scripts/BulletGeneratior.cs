using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGeneratior : MonoBehaviour
{
    [SerializeField, Header("xé≤ÇÃç≈è¨äpìx")] float _xMin;
    [SerializeField, Header("xé≤ÇÃç≈ëÂäpìx")] float _xMax;
    [SerializeField, Header("yé≤ÇÃç≈è¨äpìx")] float _yMin;
    [SerializeField, Header("yé≤ÇÃç≈ëÂäpìx")] float _yMax;
    [SerializeField, Header("zé≤ÇÃç≈è¨äpìx")] float _zMin;
    [SerializeField, Header("zé≤ÇÃç≈ëÂäpìx")] float _zMax;

    [SerializeField, Header("íeê∂ê¨Ç‹Ç≈ÇÃÉäÉ~ÉbÉgÉ^ÉCÉÄ")] float _timeRimit;
    float _currentTime; //åªç›ÇÃéûä‘

    [SerializeField, Header("Ç«ÇÃíeÇ©")] private BulletState _bulletState = BulletState.normal;
    ObjectPool _objectPool;
    GoogleSheetsReader _googleSheetsReader;

    Quaternion _initRotation;

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

        //èâä˙äpìxÇï€ë∂
        _initRotation = transform.rotation;
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
                else
                {
                    _objectPool.GetBullet(transform.position, _objectPool._objectRicochetPool);
                    GeneratiorRotation();
                    Vector3 bulletDirection = transform.forward;
                }

                //èâä˙ÇÃâÒì]Ç…ñﬂÇ∑
                transform.rotation = _initRotation;
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
    ricochet,
}
