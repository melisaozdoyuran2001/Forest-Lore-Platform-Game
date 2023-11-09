using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Animator animator;
    public float jumpForce = 6f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;
    private bool jumpRequested = false;
    public GameObject bombPerfab; 
    public float bombVelocity = 5.0f;
    private bool isFiring = false; 
    public TextMeshProUGUI GameOver ; 
    public AudioClip fireSound;
    public AudioClip coinSound; 
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetBool("isRun", horizontalInput != 0);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 1); 
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
        jumpRequested = true;
        isGrounded = false;
        }

        if (Input.GetMouseButtonDown(0)) 
    {
        Fire();
        isFiring= false; 
    }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        if (jumpRequested)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpRequested = false;
        isGrounded= false;
    }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
    
    if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = true;
    }

    if(collision.gameObject.CompareTag("DeadZone") || collision.gameObject.CompareTag("Enemy")) {
        //Debug.Log("You have died!");
        GameOver.gameObject.SetActive(true); 
        Time.timeScale = 0f; 

    }

    if(collision.gameObject.CompareTag("winBox"))
    {
        GameOver.text = "You Won";
        GameOver.gameObject.SetActive(true);
        Time.timeScale = 0f; 
    }

    if(collision.gameObject.CompareTag("coin")) {
        Destroy(collision.gameObject);
        audioSource.PlayOneShot(coinSound);
        ScoreManager.Instance.IncreaseScore(); 

    }


    }

    private void Fire()
    {isFiring = true; 
    audioSource.PlayOneShot(fireSound);
    animator.SetBool("attack" , isFiring );
    if(transform.localScale.x > 0){
         
    GameObject bomb = Instantiate(bombPerfab, transform.position + transform.right, Quaternion.identity);
   bomb.transform.localPosition = new Vector3(
    bomb.transform.localPosition.x, 
    bomb.transform.localPosition.y + 0.7f,
    bomb.transform.localPosition.z
);
    Rigidbody2D bombRB = bomb.GetComponent<Rigidbody2D>();
    bombRB.velocity = bombVelocity * transform.right;
    }
    else {
    GameObject bomb = Instantiate(bombPerfab, transform.position - transform.right, Quaternion.identity);
   bomb.transform.localPosition = new Vector3(
    bomb.transform.localPosition.x, 
    bomb.transform.localPosition.y + 0.7f,
    bomb.transform.localPosition.z
);
    Rigidbody2D bombRB = bomb.GetComponent<Rigidbody2D>();
    bombRB.velocity = bombVelocity * -transform.right;
    }
   
}

}
