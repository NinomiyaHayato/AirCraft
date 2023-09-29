using UnityEngine;

public class RicochetBullet : BulletDataBase
{
    Rigidbody _rb;
    GoogleSheetsReader _googleSheetRender;
    BulletGeneratior _bulletGenaratior;
    Vector3 _direction;
    [SerializeField, Header("åüçıÇµÇΩÇ¢No")] int _searchNum;
    int _refrectCount = 0;
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

    private Vector3 GetPlayerPosition()
    {
        var playerPos = FindObjectOfType<PlayerController>();
        return playerPos.transform.position;
    }
    public override void Hit()
    {
        //Vector3 playerPos = GetPlayerPosition();
        //Vector3 position = transform.position;
        //Vector3 reflectionDirection = (playerPos - position).normalized;
        //_rb.velocity = Vector3.zero;
        //_rb.AddForce(reflectionDirection, ForceMode.Impulse);
        //_refrectCount++;

        //if(_refrectCount > 2)
        //{
        //    _refrectCount = 0;
        //    gameObject.SetActive(false);
        //}
        gameObject.SetActive(false);
    }
}
