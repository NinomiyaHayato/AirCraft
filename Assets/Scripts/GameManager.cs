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
    ObjectPool _objectPool;
    Laser _laser;

    [SerializeField, Header("遅くした後の時間")] float _delayTime;
    public bool _timeDelay = false; //時間遅延を入れるかどうか及びタイム計測のためののフラグ
    [SerializeField,Header("ゲーム中かどうか")]　bool _inGame = true; //ゲーム中かどうか
    [SerializeField, Header("次のシーンまでの基準時間(まだ未実装)")] float _timeRimit;
    public float _currentTime;//生存時間の計測
    [SerializeField,Header("ライト")]Light _spotLight;
    public Vector3 _stagePosition;//ステージの中心座標

    [SerializeField, Header("Playerのmodel")] GameObject _drone;
    [SerializeField, Header("爆発のパーティクル")] GameObject _exprosionEffect;

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
        _objectPool = FindObjectOfType<ObjectPool>();
        _laser = FindObjectOfType<Laser>();
        _stagePosition = GameObject.Find("Stage").transform.position;
    }
    private void Update()
    {
        TimeDelay();
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
                _objectPool.Pause();
                _laser.Pause();
                _spotLight.color = Color.cyan;
            }
            else
            {
                _objectPool.Resume();
                _laser.Resume();
                _spotLight.color = Color.yellow;
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

    public void ParticleTrigger(Vector3 playerPos)
    {
        if(_inGame)
        {
            Instantiate(_exprosionEffect,playerPos,Quaternion.identity);
            Instantiate(_drone,new Vector3(playerPos.x,playerPos.y + 3,playerPos.z),new Quaternion(180,0,0,0)); 
        }
        _inGame = false;
    }

    public void AllBulletDestroy()
    {
        
    }
}
