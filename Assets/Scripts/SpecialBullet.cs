using UnityEngine;

public class SpecialBullet : BulletDataBase
{
    Rigidbody _rb;
    GoogleSheetsReader _googleSheetRender;
    BulletGeneratior _bulletGenaratior;
    Vector3 _direction;
    [SerializeField, Header("õµ½¢No")] int _searchNum;

    private void Start()
    {
        _googleSheetRender = FindObjectOfType<GoogleSheetsReader>();
        if (_googleSheetRender.IsDataLoading())
        {
            _rb = GetComponent<Rigidbody>();

            _speed = BulletSpeed(_searchNum);
        }
    }
    private void OnEnable()
    {
        _bulletGenaratior = FindFirstObjectByType<BulletGeneratior>();
        _direction = _bulletGenaratior.transform.forward;
    }
    private void Update()
    {
        _rb.velocity = _direction.normalized * _speed * 1.5f;
    }

    public override void Hit()
    {
        gameObject.SetActive(false);
    }
}
