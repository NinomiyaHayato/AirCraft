using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _v; //vertical
    float _h; //holizontal
    Rigidbody _rb;
    Vector3 _dir;
    [SerializeField, Header("à⁄ìÆë¨ìx")] int _moveSpeed;
    private Quaternion _quaternionFirst;//playerÇÃäpìxí≤êÆÇÃÇΩÇﬂÇ…èâä˙äpìxÇÃï€ë∂
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
        _dir = Vector3.forward * _h + Vector3.right * _v;
        _dir = Camera.main.transform.TransformDirection(_dir);
        if(_v != 0 || _h != 0)
        {
            transform.forward = _dir;
        }
        _rb.velocity = _dir.normalized * _moveSpeed + _rb.velocity.y * Vector3.up;
    }
}
