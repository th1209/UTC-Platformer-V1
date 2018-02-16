using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatedMove : MonoBehaviour
{
    // 移動の開始位置と終了位置｡
    // 対象のオブジェクトのローカル座標で指定する｡
    // ※ ネストしている場合､ワールド座標で指定しないように注意｡
    [SerializeField]
    private Vector3 _startPosition = Vector3.zero;

    [SerializeField]
    private Vector3 _endPosition = Vector3.zero;

    [SerializeField]
    private float _loopTime = 1.0f;

    private float _curTime = 0.0f;

    private bool _reverse = false;

    void Start()
    {
        // 親オブジェクトのpositionを足しこんで､インスペクタ上で設定したローカル座標をワールド座標に変換｡
        Transform current = transform;
        do
        {
            Transform parent = current.parent;
            current = parent;
            if (parent == null)
                break;
            _startPosition += parent.position;
            _endPosition   += parent.position;

        } while(true);
    }

    void Update()
    {
        Vector3 from = (! _reverse) ? _startPosition : _endPosition;
        Vector3 to   = (! _reverse) ? _endPosition : _startPosition;

        _curTime += Time.deltaTime;
        transform.position = Vector3.Lerp(from, to, _curTime / _loopTime);

        if (_curTime > _loopTime)
        {
            _curTime = 0.0f;
            _reverse = ! _reverse;
        }
    }
}
