using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private bool isGrounded;
    private string GroundTag = "Ground";

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        _rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    private void PlayerMove()
    {
        transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
    }

    void AnimatePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("IsMoving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKey("space") && isGrounded)
        //if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            _rigidbody.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            isGrounded = true;
        }
    }
}
