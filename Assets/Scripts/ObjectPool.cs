using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("最初にオブジェクトを何個生成するか")] int _maxCount;
    [SerializeField, Header("生成するGameObject")] GameObject _bullet;
    List<GameObject> _objectPool;
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreatePool()
    {
        _objectPool = new List<GameObject>();
        for(int i = 0; i < _maxCount; i++)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.SetActive(false);
            _objectPool.Add(bullet);
        }
    }
    public GameObject GetBullet(Vector3 position)
    {
        for(int i = 0; i < _objectPool.Count; i++)
        {
            if(_objectPool[i].activeSelf == false)
            {
                GameObject bullet = _objectPool[i];
                bullet.SetActive(true);
                return bullet;
            }
        }
        //全てObjectを使用していた場合
        GameObject newBullet = Instantiate(_bullet, position, transform.rotation);
        newBullet.SetActive(false);
        _objectPool.Add(newBullet);
        return newBullet;
    }
}
