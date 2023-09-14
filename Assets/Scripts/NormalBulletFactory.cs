using UnityEngine;

public class NormalBulletFactory : ObjectFactory
{
    [SerializeField, Header("í èÌÇÃíe")] GameObject _normalBullet;

    public  GameObject CreateObject(Vector3 position)
    {
        GameObject bullet = UnityEngine.GameObject.Instantiate(_normalBullet, position,Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }
}
