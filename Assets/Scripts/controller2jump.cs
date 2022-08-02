using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller2jump : MonoBehaviour
{
    public float jumpForce = 1.0f;
    public float speed = 4.0f;
    public float moveDirection;
    private bool jump;
    private bool moving;
    private bool grounded = true;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if(_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        _rigidbody2D.velocity = new Vector2(speed * moveDirection , _rigidbody2D.velocity.y);
        if(jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }
    void Update()
    {
        if(grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if(Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f; // sola git
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed",speed);
            }
            else if(Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f; // sağa git
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed",speed);
            }
        }
        else if(grounded == true)
        {
            moveDirection = 0;
            anim.SetFloat("speed",0.0f);
        }
        if(grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded",false);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "zemin")
        {
            anim.SetBool("grounded",true);
            grounded = true;
            Debug.Log("Çarpişma!");
        }
    }
}
