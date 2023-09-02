using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _v; //vertical
    float _h; //holizontal
    Rigidbody _rb;
    Vector3 _dir;
    [SerializeField, Header("�ړ����x")] int _moveSpeed;
    private Quaternion _quaternionFirst;//player�̊p�x�����̂��߂ɏ����p�x�̕ۑ�
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _quaternionFirst = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        _v = Input.GetAxisRaw("Vertical");
        _h = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        _dir = Vector3.forward * _h + Vector3.up * _v;
        _rb.velocity = _dir.normalized * _moveSpeed;
        VerticalRotation();
        HolizontalRoration();
    }
    private void VerticalRotation()�@//player�̊p�x����
    {
        if (_h > 0)
        {
            this.transform.rotation = _quaternionFirst * Quaternion.Euler(25f, 0f, 0f);
        }
        else if (_h < 0)
        {
            this.transform.rotation = _quaternionFirst * Quaternion.Euler(-25f, 0f, 0f);
        }
        else if(_h == 0 && _v == 0)
        {
            this.transform.rotation = _quaternionFirst;
        }
    }
    private void HolizontalRoration() //player�̊p�x����
    {
        if (_v > 0)
        {
            this.transform.rotation = _quaternionFirst * Quaternion.Euler(0f, 0f, -10f);
        }
        else if (_v < 0)
        {
            this.transform.rotation = _quaternionFirst * Quaternion.Euler(0f, 0f, 10f);
        }
        else if(_v == 0 && _h == 0)
        {
            this.transform.rotation = _quaternionFirst;
        }
    }
}
