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

    [SerializeField, Header("�x��������̎���")] float _delayTime;
    public bool _timeDelay = false; //���Ԓx�������邩�ǂ����y�у^�C���v���̂��߂̂̃t���O
    [SerializeField,Header("�Q�[�������ǂ���")]�@bool _inGame = true; //�Q�[�������ǂ���
    [SerializeField, Header("���̃V�[���܂ł̊����(�܂�������)")] float _timeRimit;
    public float _currentTime;//�������Ԃ̌v��
    [SerializeField,Header("���C�g")]Light _spotLight;
    public Vector3 _stagePosition;//�X�e�[�W�̒��S���W

    [SerializeField, Header("Player��model")] GameObject _drone;
    [SerializeField, Header("�����̃p�[�e�B�N��")] GameObject _exprosionEffect;

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
        // GameManager�̃C���X�^���X��V�������̂ɒu��������
        _instance = null;
    }

    public void TimeDelay() //���Ԃ̒x��
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

    public void MemoryTime(bool timeJudge) //�������Ԃ̌v���Ǝ��Ԃ̋L�^
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
