using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour
{

    [SerializeField]
    private float _runSpeed = 6.0f;

    [SerializeField]
    private float _jumpSpeed = 8.0f;

    [SerializeField]
    private float _gravity = 20.0f;

    private Animator _animator;

    private CharacterController _character;

    private Vector3 _moveDirection = Vector3.zero;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<CharacterController>();
    }

    void Update()
    {
        UpdateAnimator();
        UpdateCharacter();
    }

    private void UpdateAnimator()
    {
        if (_character.isGrounded)
        {
            _animator.SetFloat("RunSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));

            if (Input.GetButtonDown("Jump"))
            {
                _animator.SetBool("IsJumping", true);
            }
            else
            {
                _animator.SetBool("IsJumping", false);

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _animator.SetTrigger("Salute");
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    _animator.SetTrigger("KneelDown");
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _animator.SetTrigger("Die");
                }
            }
        }
    }

    private void UpdateCharacter()
    {
        float h = Input.GetAxis("Horizontal");
        if (_character.isGrounded)
        {
            _moveDirection = new Vector3(0, 0, h);
            _moveDirection *= _runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                _moveDirection.y = _jumpSpeed;
            }
        }

        _moveDirection.y -= _gravity * Time.deltaTime;
        _character.Move(_moveDirection * Time.deltaTime);

        if (h > 0 || h < 0)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, 0, h));
            transform.rotation = lookRotation;
        }
    }

    public void OnCallChangeFace()
    {

    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 250, 150), "Manipulation");
        GUI.Label(new Rect(20, 30,  250, 30), "Move : Left/Right Arrow");
        GUI.Label(new Rect(20, 50,  250, 30), "Jump : Space");
        GUI.Label(new Rect(20, 70,  250, 30), "Salute : Q");
        GUI.Label(new Rect(20, 90,  250, 30), "KneelDown : W");
        GUI.Label(new Rect(20, 110, 250, 30), "Die : E");
    }

}
