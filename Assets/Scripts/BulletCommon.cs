using UnityEngine;

public class BulletCommon : MonoBehaviour
{
    public int _bulletDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IHealthDamageable _healthDamageable = collision.gameObject.GetComponent<IHealthDamageable>();

            if (_healthDamageable != null)
            {
                _healthDamageable.TakeDamage(_bulletDamage);
                gameObject.SetActive(false);
            }
        }
        else if (collision.gameObject.tag == "Fiald")
        {
            var bulletHit = GetComponent<BulletDataBase>();
            bulletHit.Hit();
        }
    }
}
