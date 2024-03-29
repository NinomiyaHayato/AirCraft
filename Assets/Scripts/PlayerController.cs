using UnityEngine;

public class PlayerController : MonoBehaviour,IHealthDamageable
{
    public float _v; //vertical
    public float _h; //holizontal
    Rigidbody _rb;
    Vector3 _dir;
    [SerializeField, Header("移動速度")] int _moveSpeed;
    [SerializeField, Header("体力")] int _hp;
    
    GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        _v = Input.GetAxisRaw("Vertical");
        _h = Input.GetAxisRaw("Horizontal");
        if (_hp <= 0)
        {
            GameManager.Instance.ParticleTrigger(this.transform.position);
            Destroy(gameObject, 0.1f);
        }
    }
    private void FixedUpdate()
    {
        _dir = Vector3.forward * _v + Vector3.right * _h;
        _dir = Camera.main.transform.TransformDirection(_dir);
        if(_v != 0 || _h != 0)
        {
            transform.forward = _dir;
        }
        _rb.velocity = _dir.normalized * _moveSpeed;
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        
        if(_hp <= 0)
        {
            _gameManager.MemoryTime(false);
            Destroy(gameObject,0.5f);
        }
    }
}
