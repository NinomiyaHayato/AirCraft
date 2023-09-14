using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("最初にオブジェクトを何個生成するか")] int _maxCount;

    List<GameObject> _objectPool;

    ObjectFactory _currentFactory; //今のfactory

    [SerializeField] NormalBulletFactory _normalBlletFactory;
    [SerializeField] SpecialBuleetFactory _specialBulletFactory;


    private void Awake()
    {
        SetFactory(_normalBlletFactory);
        CreatePool();
    }
    public void SetFactory(ObjectFactory factory) //factoryの切り替え
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
        //全てObjectを使用していた場合
        GameObject newBullet = _currentFactory.CreateObject(position);
        _objectPool.Add(newBullet);
        return newBullet;
    }
}
