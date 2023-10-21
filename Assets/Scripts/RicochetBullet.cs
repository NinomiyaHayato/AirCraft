using UnityEngine;

public class RicochetBullet : BulletDataBase
{
    Rigidbody _rb;
    GoogleSheetsReader _googleSheetRender;
    BulletGeneratior _bulletGenaratior;
    Vector3 _direction;
    [SerializeField, Header("åüçıÇµÇΩÇ¢No")] int _searchNum;
    [SerializeField]int _refrectCount = 0;

    public bool RefrectBool
    {
        get
        {
            return _refrectCount == 0;
        }
    }
    private void Start()
    {
        _googleSheetRender = FindObjectOfType<GoogleSheetsReader>();
        if (_googleSheetRender.IsDataLoading())
        {
            _rb = GetComponent<Rigidbody>();

            _speed = BulletSpeed(_searchNum);
            if (RefrectBool) { _rb.AddForce(_direction * _speed * 3f, ForceMode.Impulse); }
        }
    }
    private void OnEnable()
    {
        _bulletGenaratior = FindFirstObjectByType<BulletGeneratior>();
        _direction = _bulletGenaratior.transform.forward;
    }
    private void OnDisable()
    {
        _refrectCount = 0;
    }
    private void Update()
    {
        
    }
    public override void Hit()
    {
        if (_refrectCount == 0)
        {
            Vector3 stagePosition = GameManager.Instance._stagePosition;
            stagePosition = new Vector3(stagePosition.x += Random.Range(-10, 10), stagePosition.y += Random.Range(-10, 10), stagePosition.z += Random.Range(-10, 10));
            _rb.velocity = Vector3.zero;
            _rb.AddForce(stagePosition * _speed, ForceMode.Impulse);
            _refrectCount++;
        }
        else { gameObject.SetActive(false); }
    }
}
