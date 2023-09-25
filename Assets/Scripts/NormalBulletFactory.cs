using UnityEngine;

[CreateAssetMenu(fileName = "NormalBulletFactory", menuName = "Object Factories/Normal Bullet Factory")]
public class NormalBulletFactory : ObjectFactory
{
    [SerializeField, Header("í èÌÇÃíe")] GameObject _normalBullet;

    public override GameObject CreateObject(Vector3 position)
    {
        GameObject bullet = UnityEngine.GameObject.Instantiate(_normalBullet, position,Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }
}
