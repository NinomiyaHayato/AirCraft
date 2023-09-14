using UnityEngine;

[CreateAssetMenu(fileName = "SpecialBulletFactory", menuName = "Object Factories/Special Bullet Factory")]
public class SpecialBuleetFactory : ScriptableObject,ObjectFactory
{
    [SerializeField, Header("����Ȓe")] GameObject _specialBullet;

    public  GameObject CreateObject(Vector3 position)
    {
        GameObject bullet = UnityEngine.GameObject.Instantiate(_specialBullet, position, Quaternion.identity);
        bullet.SetActive(false);
        return bullet;
    }
}
