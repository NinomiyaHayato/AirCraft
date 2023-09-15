using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("�ŏ��ɒʏ�̃I�u�W�F�N�g�����������邩")] int _maxNormalCount;
    [SerializeField, Header("�ŏ��ɓ���ȃI�u�W�F�N�g�����������邩")] int _maxSpecialCount;

    List<GameObject> _objectNormalPool = new List<GameObject>();
    List<GameObject> _objectSpecialPool = new List<GameObject>();

    ObjectFactory _currentFactory; //����factory

    [SerializeField] NormalBulletFactory _normalBlletFactory;
    [SerializeField] SpecialBuleetFactory _specialBulletFactory;


    private void Awake()
    {
        SetFactory(_normalBlletFactory);
        CreatePool(_maxNormalCount,_objectNormalPool);
        SetFactory(_specialBulletFactory);
        CreatePool(_maxSpecialCount, _objectSpecialPool);
    }
    public void SetFactory(ObjectFactory factory) //factory�̐؂�ւ�
    {
        _currentFactory = factory;
    }

    public void CreatePool(int maxCount,List<GameObject> pool)
    {
        for(int i = 0; i < maxCount; i++)
        {
            GameObject bullet = _currentFactory.CreateObject(Vector3.zero);
            bullet.SetActive(false);
            pool.Add(bullet);
            bullet.transform.parent = this.transform;
        }
    }
    public GameObject GetBullet(Vector3 position)
    {
        for(int i = 0; i < _objectNormalPool.Count; i++)
        {
            if(_objectNormalPool[i].activeSelf == false)
            {
                GameObject bullet = _objectNormalPool[i];
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        //�S��Object���g�p���Ă����ꍇ
        GameObject newBullet = _currentFactory.CreateObject(position);
        _objectNormalPool.Add(newBullet);
        return newBullet;
    }
}
