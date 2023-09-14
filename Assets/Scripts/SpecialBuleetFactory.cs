using UnityEngine;

public class SpecialBuleetFactory : ObjectFactory
{
    [SerializeField, Header("“ÁŽê‚È’e")] GameObject _specialBullet;

    public  GameObject CreateObject(Vector3 position)
    {
        GameObject bullet = UnityEngine.GameObject.Instantiate(_specialBullet, position, Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }
}
