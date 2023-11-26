using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class BulletDataBase : MonoBehaviour
{
    [SerializeField, Header("スピード")]protected int _speed = 0;

    public void Set(Vector3 direction)
    {
        transform.forward = direction;
    }

    public int BulletSpeed(int num)
    {
        GoogleSheetsManager manager = GoogleSheetsManager.GetInstance();
        if(manager._sheetsData != null)
        {
            var bullet = manager._sheetsData.data.FirstOrDefault(item => item.No == num);

            if(bullet != null)
            {
                int speed = bullet.発射速度;
                return speed;
            }
        }
        return 0;
    }

    public abstract void Hit();
}
