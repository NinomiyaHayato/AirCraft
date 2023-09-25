using UnityEngine;

[CreateAssetMenu(fileName = "SpecialBulletFactory", menuName = "Object Factories/Special Bullet Factory")]
public class SpecialBuleetFactory : ObjectFactory
{
    [SerializeField, Header("“ÁŽê‚È’e")] GameObject _specialBullet;

    public override GameObject CreateObject(Vector3 position)
    {
        GameObject bullet = UnityEngine.GameObject.Instantiate(_specialBullet, position, Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }
}
