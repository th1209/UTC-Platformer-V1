using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class StageControl : MonoBehaviour
{
    public enum STATE
    {
        // 初期化タイミング.
        START,
        // プレイ中.
        PLAY,
        // ゴール時処理タイミング.
        GOAL,
    };


    [SerializeField]
    private Vector3 _defaultCharacterInstantiatePoint = new Vector3(0, 1, 3);

    public Vector3 CharacterInstantiatePoint
    {
        get { return _characterInstantiatePoint; }
        set { _characterInstantiatePoint = value; }
    }
    private Vector3 _characterInstantiatePoint;

    [SerializeField]
    private GameObject _characterPrefab;

    private STATE _state = STATE.START;

    private CharacterControl _character;

    void Start()
    {
        ResetCharacterInstantiatePoint();
    }

    void Update()
    {
        switch (_state)
        {
            case STATE.START:
                // TODO:
                // Prefab上でUTCに"Player"タグを付けている。
                // スクリプト上でタグ付けしてやりたい。
                GameObject cGo = Instantiate(_characterPrefab, CharacterInstantiatePoint, Quaternion.identity);
                _character = cGo.GetComponent<CharacterControl>();
                _state = STATE.PLAY;
                break;
            case STATE.PLAY:
                break;
            case STATE.GOAL:
                // TODO:
                // 後で処理を置き換えること｡
                // ･他ステージ選択UI表示
                // ･UTCにアニメーションさせる
                ResetCharacterInstantiatePoint();
                SceneManager.LoadScene("Stage1Experiment");
                break;
        }
    }

    void ResetCharacterInstantiatePoint()
    {
        CharacterInstantiatePoint = _defaultCharacterInstantiatePoint;
    }


    public void UpdateCharacterInstantiatePoint(Vector3 updatePoint)
    {
        Assert.IsTrue(_state == STATE.PLAY);
        CharacterInstantiatePoint = updatePoint;
    }

    public void ChangeStage(STATE to)
    {
        if (_state != to)
            _state = to;
    }
}
