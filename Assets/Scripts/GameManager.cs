using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    GoogleSheetsReader _googleSheetsReader;
    PlayerController _playerController;
    RankingSystem _rankingSystem;

    [SerializeField, Header("遅くした後の時間")] float _delayTime;
    bool _timeDelay = false; //時間遅延を入れるかどうか及びタイム計測のためののフラグ
    [SerializeField,Header("ゲーム中かどうか")]　bool _inGame = false; //ゲーム中かどうか
    [SerializeField, Header("次のシーンまでの基準時間(まだ未実装)")] float _timeRimit;
    public float _currentTime;//生存時間の計測
    [SerializeField,Header("ライト")]Light _spotLight;
    public Vector3 _stagePosition;//ステージの中心座標

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
        _rankingSystem = FindObjectOfType<RankingSystem>();
        _stagePosition = GameObject.Find("Stage").transform.position;
    }
    private void Update()
    {
        //TimeDelay();
    }

    public void ReStart()
    {
        // GameManagerのインスタンスを新しいものに置き換える
        _instance = null;
    }

    public void TimeDelay() //時間の遅延
    {
        if(_googleSheetsReader.IsDataLoading())
        {
            _timeDelay = true;
            MemoryTime(true);
        }

        if(_timeDelay)
        {
            if (_playerController._h == 0 && _playerController._v == 0)
            {
                Time.timeScale = _delayTime;
                _spotLight.color = Color.white;
            }
            else
            {
                Time.timeScale = 1.0f;
                _spotLight.color = Color.red;
            }
        }
    }

    public void MemoryTime(bool timeJudge) //生存時間の計測と時間の記録
    {
        if (timeJudge)
        {
            _currentTime += Time.deltaTime;
        }
        else
        {
            float timeRecord = _currentTime;
            _rankingSystem.AddPlayerScore(timeRecord);
            var playerScores = _rankingSystem.GetScore(5);

            foreach(var socre in playerScores)
            {
                Debug.Log(socre._score);
            }
        }
    }
}
