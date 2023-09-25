using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("�ŏ��ɒʏ�̃I�u�W�F�N�g�����������邩")] int _maxNormalCount;
    [SerializeField, Header("�ŏ��ɓ���ȃI�u�W�F�N�g�����������邩")] int _maxSpecialCount;

    public List<GameObject> _objectNormalPool = new List<GameObject>();
    public List<GameObject> _objectSpecialPool = new List<GameObject>();

    ObjectFactory _currentFactory; //����factory

    [SerializeField] NormalBulletFactory _normalBlletFactory;
    [SerializeField] SpecialBuleetFactory _specialBulletFactory;


    private void Awake()
    {
        CreatePool(_maxNormalCount,_objectNormalPool,_normalBlletFactory);
        CreatePool(_maxSpecialCount, _objectSpecialPool,_specialBulletFactory);
    }

    public void CreatePool(int maxCount,List<GameObject> pool,ObjectFactory factory)
    {
        for(int i = 0; i < maxCount; i++)
        {
            GameObject bullet = factory.CreateObject(Vector3.zero);
            bullet.SetActive(false);
            pool.Add(bullet);
            bullet.transform.parent = this.transform;
        }
    }
    public GameObject GetBullet(Vector3 position,List<GameObject> pool)
    {
        for(int i = 0; i < pool.Count; i++)
        {
            if(pool[i].activeSelf == false)
            {
                GameObject bullet = pool[i];
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        //�S��Object���g�p���Ă����ꍇ
        GameObject newBullet = _currentFactory.CreateObject(position);
        pool.Add(newBullet);
        return newBullet;
    }
}
