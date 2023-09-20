using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleSheetsManager : MonoBehaviour
{
    public GoogleSheetsData _sheetsData;

    //シングルトンインスタンス

    private static GoogleSheetsManager _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GoogleSheetsManager GetInstance()
    {
        return _instance;
    }
}
