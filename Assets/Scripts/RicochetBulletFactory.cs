using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RicochetBulletFactory", menuName = "Object Factories/Ricochet Bullet Factory")]
public class RicochetBulletFactory : ObjectFactory
{
    [SerializeField, Header("’µ’e")] GameObject _ricochetBullet;
    public override GameObject CreateObject(Vector3 position)
    {
        GameObject bullet = UnityEngine.GameObject.Instantiate(_ricochetBullet, position, Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }
}
