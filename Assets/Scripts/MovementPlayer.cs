
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;


    private Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    bool moveRight = true, moveLeft = false;
    private bool touchingGround = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround == true)
        {
            touchingGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("IsJumping");
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Fire");
        }

    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        {
            if (horizontal > 0.01)
            {
            if(transform.position.x<147)
            {
                moveRight = true;
                moveLeft = false;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                if(transform.position.x>GameObject.Find("PlayerRecords").GetComponent<Records>().Score)
                    GameObject.Find("PlayerRecords").GetComponent<Records>().Score = transform.position.x+7;
            }  
            else if(transform.position.x>147|| transform.position.y<4)   
            {
                SceneManager.LoadScene(1);
            }
            }  
            else if (horizontal < -0.01)
            {
                moveRight = false;
                moveLeft = true;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            anim.SetFloat("RightWalk", horizontal);

            float moveX = horizontal * 10 * Time.deltaTime * movementSpeed;
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchingGround = true;

        }
    }
}
