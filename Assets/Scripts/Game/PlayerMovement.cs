using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove = 2;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    public bool isIdle;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (_rigidbody2D.velocity.x < 0.9 && _rigidbody2D.velocity.x > -0.9)
            isIdle = true;
        else
            isIdle = false;

        Debug.Log(_rigidbody2D.velocity);
        _animator.SetFloat("Speed", _rigidbody2D.velocity.x);
        _animator.SetBool("Idle", isIdle);

    }
    private void FixedUpdate()
    {
        

    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {

            //transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * _speedMove;
            //_rigidbody2D.AddForce(new Vector2(-1, 0) * Time.deltaTime * _speedMove);
            _rigidbody2D.velocity = new Vector2(-1, 0) * _speedMove;
        }
        if (Input.GetKey(KeyCode.D))
        {

            //transform.position += new Vector3(1, 0,0) * Time.deltaTime * _speedMove;
            //_rigidbody2D.AddForce(new Vector2(1, 0) * Time.deltaTime * _speedMove);
            _rigidbody2D.velocity = new Vector2(1, 0) * _speedMove;
        }
        if (Input.GetKey(KeyCode.Space))
        {

            //transform.position += new Vector3(0, 1, 0)  * _speedMove/10;
            //_rigidbody2D.AddForce(new Vector2(1, 0) * Time.deltaTime * _speedMove);
            _rigidbody2D.velocity = new Vector2(0, 1) * _speedMove * 2;
        }
        if (Input.GetKey(KeyCode.E))
        {
            
            _animator.SetTrigger("Attack");
        }
        if (Input.GetKey(KeyCode.R))
        {
            
            _animator.SetTrigger("Throw");
        }
    }
}
