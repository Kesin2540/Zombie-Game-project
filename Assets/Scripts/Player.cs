using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    Animator Anim;
    private Rigidbody rb;
    private bool jump = false;
    private AudioSource audioSource;

    [SerializeField] float jumpForce;
    [SerializeField] AudioClip sfxJump;
    [SerializeField] AudioClip sfxDeath;
    // Start is called before the first frame update

    public Rigidbody zombie()
    {
        return rb;
    }

    private void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
    }
    void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    { 
        if (!GameManager.Instance.GameOver && GameManager.Instance.GameStart)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameManager.Instance.PlayerStartedGame();
                Anim.Play("jump");
                audioSource.PlayOneShot(sfxJump);
                rb.useGravity = true;
                jump = true;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if( jump == true )
        {
            jump = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            rb.AddForce(new Vector3 (transform.position.x, -20, 50), ForceMode.Impulse);
            rb.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.Instance.PlayerCollided();
        }
    }
}
