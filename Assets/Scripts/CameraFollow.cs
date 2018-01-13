using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _smoothing = 5.0f;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing * Time.deltaTime);
    }
}