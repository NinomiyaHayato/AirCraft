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
        _rb.AddForce(_direction.normalized * _speed, ForceMode.Impulse);
    }
    private void OnDisable()
    {
        if(_refrectCount != 0) { _refrectCount = 0; }
    }
    private void Update()
    {
        //_rb.velocity = _direction.normalized * _speed * 1.5f;
    }
    public override void Hit()
    {
        if (_refrectCount == 0)
        {
            Vector3 stagePosition = GameManager.Instance._stagePosition;
            stagePosition = new Vector3(stagePosition.x += Random.Range(-10, 10), stagePosition.y += Random.Range(-10, 10), stagePosition.z += Random.Range(-10, 10));
            _rb.AddForce(stagePosition, ForceMode.Impulse);
        }
        else { gameObject.SetActive(false); }
    }
}
