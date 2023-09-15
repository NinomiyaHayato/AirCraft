using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("最初に通常のオブジェクトを何個生成するか")] int _maxNormalCount;
    [SerializeField, Header("最初に特殊なオブジェクトを何個生成するか")] int _maxSpecialCount;

    List<GameObject> _objectNormalPool = new List<GameObject>();
    List<GameObject> _objectSpecialPool = new List<GameObject>();

    ObjectFactory _currentFactory; //今のfactory

    [SerializeField] NormalBulletFactory _normalBlletFactory;
    [SerializeField] SpecialBuleetFactory _specialBulletFactory;


    private void Awake()
    {
        SetFactory(_normalBlletFactory);
        CreatePool(_maxNormalCount,_objectNormalPool);
        SetFactory(_specialBulletFactory);
        CreatePool(_maxSpecialCount, _objectSpecialPool);
    }
    public void SetFactory(ObjectFactory factory) //factoryの切り替え
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
        //全てObjectを使用していた場合
        GameObject newBullet = _currentFactory.CreateObject(position);
        _objectNormalPool.Add(newBullet);
        return newBullet;
    }
}
