using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public AudioClip dieAudioClip;

    public float jumpForce = 300f;
    private int jumpCount = 0;

    private Animator anim;
    private Rigidbody2D rd2d;
    private AudioSource audioSource;

    private bool isDead = false;
    private bool isGrounded = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rd2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && jumpCount < 2) //0 좌클릭
        {
            ++jumpCount;
            rd2d.velocity = Vector2.zero; //넣고 2단 해보고 안넣고 2단 점프 해봐서 차이점 확인
            rd2d.AddForce(Vector2.up * jumpForce);
            audioSource.Play();
        }
        if (Input.GetMouseButtonUp(0) && rd2d.velocity.y > 0) //0 좌클릭
        {
            rd2d.velocity = rd2d.velocity * 0.5f;
        }
        if(Input.GetMouseButton(1))
        {
            rd2d.velocity = Vector2.zero;
            Debug.Log("우클릭");
        }
        anim.SetBool("Grounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            if (collision.contacts[0].normal.y > 0.7f)
            {
                isGrounded = true;
                jumpCount = 0;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dead") && !isDead)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;

        anim.SetTrigger("Die");
        rd2d.velocity = Vector2.zero;

        audioSource.clip = dieAudioClip;
        audioSource.Play();

        GameManager.instance.OnPlayerDead();
    }
}