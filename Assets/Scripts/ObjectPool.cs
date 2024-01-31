using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Header("最初に通常のオブジェクトを何個生成するか")] int _maxNormalCount;
    [SerializeField, Header("最初に特殊なオブジェクトを何個生成するか")] int _maxSpecialCount;
    [SerializeField, Header("最初に跳弾するオブジェクトを何個生成するか")] int _maxRicochetCount;

    public List<GameObject> _objectNormalPool = new List<GameObject>();
    public List<GameObject> _objectSpecialPool = new List<GameObject>();
    public List<GameObject> _objectRicochetPool = new List<GameObject>();

    [SerializeField] ObjectFactory _bulletFactory; // 通常の弾、特殊な弾、跳弾を生成するためのファクトリー


    private void Awake()
    {
        CreatePool(_maxNormalCount, _objectNormalPool, _bulletFactory, _bulletFactory.CreateNormalBullet);
        CreatePool(_maxSpecialCount, _objectSpecialPool, _bulletFactory, _bulletFactory.CreateSpecialBullet);
        CreatePool(_maxRicochetCount, _objectRicochetPool, _bulletFactory, _bulletFactory.CreateRicochetBullet);
    }

    public void CreatePool(int maxCount, List<GameObject> pool, ObjectFactory factory, Func<Vector3, GameObject> createMethod)
    {
        for (int i = 0; i < maxCount; i++)
        {
            GameObject bullet = createMethod(Vector3.zero);
            bullet.SetActive(false);
            pool.Add(bullet);
            bullet.transform.parent = this.transform;
        }
    }

    public GameObject GetBullet(Vector3 position, List<GameObject> pool)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeSelf == false)
            {
                GameObject bullet = pool[i];
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }
        //全てObjectを使用していた場合
        GameObject newBullet;
        if (pool == _objectNormalPool)
        {
            newBullet = _bulletFactory.CreateNormalBullet(position);
            return newBullet;
        }
        else if (pool == _objectSpecialPool)
        {
            newBullet = _bulletFactory.CreateSpecialBullet(position);
            return newBullet;
        }
        else
        {
            newBullet = _bulletFactory.CreateRicochetBullet(position);
            return newBullet;
        }
    }

    //下記からpause/resume機能

    public void Pause()
    {
        PauseResumeHelper(_objectNormalPool,true);
        PauseResumeHelper(_objectSpecialPool,true);
        PauseResumeHelper(_objectRicochetPool,true);
    }

    public void Resume()
    {
        PauseResumeHelper(_objectNormalPool,false);
        PauseResumeHelper(_objectSpecialPool,false);
        PauseResumeHelper(_objectRicochetPool,false);
    }

    private void PauseResumeHelper(List<GameObject> pool,bool isWhich)
    {
        foreach(var bullet in pool)
        {
            if(bullet.activeSelf)
            {
                IPause pause = bullet.GetComponent<IPause>();
                if(pause != null)
                {
                    if (isWhich) { pause.Pause(); }
                    else { pause.Resume(); }
                }
            }
        }
    }
}
