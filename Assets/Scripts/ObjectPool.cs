using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("�ŏ��ɃI�u�W�F�N�g�����������邩")] int _maxCount;

    List<GameObject> _objectPool;

    ObjectFactory _currentFactory; //����factory

    [SerializeField] NormalBulletFactory _normalBlletFactory;
    [SerializeField] SpecialBuleetFactory _specialBulletFactory;


    private void Awake()
    {
        SetFactory(_normalBlletFactory);
        CreatePool();
    }
    public void SetFactory(ObjectFactory factory) //factory�̐؂�ւ�
    {
        _currentFactory = factory;
    }

    public void CreatePool()
    {
        _objectPool = new List<GameObject>();
        for(int i = 0; i < _maxCount; i++)
        {
            GameObject bullet = _currentFactory.CreateObject(Vector3.zero);
            bullet.SetActive(false);
            _objectPool.Add(bullet);
            bullet.transform.parent = this.transform;
        }
    }
    public GameObject GetBullet(Vector3 position)
    {
        for(int i = 0; i < _objectPool.Count; i++)
        {
            if(_objectPool[i].activeSelf == false)
            {
                GameObject bullet = _objectPool[i];
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        //�S��Object���g�p���Ă����ꍇ
        GameObject newBullet = _currentFactory.CreateObject(position);
        _objectPool.Add(newBullet);
        return newBullet;
    }
}
