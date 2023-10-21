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

    [SerializeField, Header("�x��������̎���")] float _delayTime;
    bool _timeDelay = false; //���Ԓx�������邩�ǂ����y�у^�C���v���̂��߂̂̃t���O
    [SerializeField,Header("�Q�[�������ǂ���")]�@bool _inGame = false; //�Q�[�������ǂ���
    [SerializeField, Header("���̃V�[���܂ł̊����(�܂�������)")] float _timeRimit;
    public float _currentTime;//�������Ԃ̌v��
    [SerializeField,Header("���C�g")]Light _spotLight;
    public Vector3 _stagePosition;//�X�e�[�W�̒��S���W

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
}
