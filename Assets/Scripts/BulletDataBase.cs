using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletDataBase : MonoBehaviour
{
    [SerializeField, Header("ŒŸõ‚µ‚½‚¢No")]protected int _searchNum;
    public int BulletSpeed(int num)
    {
        GoogleSheetsManager manager = GoogleSheetsManager.GetInstance();

        if(manager._sheetsData != null)
        {
            var bullet = manager._sheetsData.data.FirstOrDefault(item => item.No == num);

            if(bullet != null)
            {
                int speed = bullet.”­ŽË‘¬“x;
                return speed;
            }
        }
        return 0;
    }
}
