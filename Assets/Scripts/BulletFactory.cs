using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletFactory", menuName = "Object Factories/Bullet Factory")]
public class BulletFactory : ObjectFactory
{
    [SerializeField, Header("í èÌÇÃíeä€")] GameObject _normalBullet;
    [SerializeField, Header("ì¡éÍÇ»íeä€")] GameObject _specialBullet;
    [SerializeField, Header("íµíeÇ∑ÇÈíeä€")] GameObject _ricochetBullet;

    public override GameObject CreateNormalBullet(Vector3 position)
    {
        GameObject bullet = GameObject.Instantiate(_normalBullet, position, Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }

    public override GameObject CreateSpecialBullet(Vector3 position)
    {
        GameObject bullet = GameObject.Instantiate(_specialBullet, position, Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }

    public override GameObject CreateRicochetBullet(Vector3 position)
    {
        GameObject bullet = GameObject.Instantiate(_ricochetBullet, position, Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }
}
