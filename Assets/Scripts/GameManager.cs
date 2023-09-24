using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    GoogleSheetsReader _googleSheetsReader;
    PlayerController _playerController;
    bool _timeDelay = false; //時間遅延を入れるかどうかのフラグ

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();

                if(_instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameManager");
                    _instance = gameManagerObject.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        _googleSheetsReader = FindObjectOfType<GoogleSheetsReader>();
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void ReStart()
    {
        // GameManagerのインスタンスを新しいものに置き換える
        _instance = null;
    }

    public void TimeDelay()
    {
        if(_googleSheetsReader.IsDataLoading())
        {
            _timeDelay = true;
        }

        if(_timeDelay)
        {

        }
    }
}
