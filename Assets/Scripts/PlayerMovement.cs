using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float jumnpForce;
    public int extraJumpValues;
    private int extraJumps;

    private bool isGrounded;
    public Transform groundPos;
    public LayerMask ground;


    private Rigidbody2D rb;
    private float  moveInput;
    public bool facingRight=true;
    public float checkRadius;

    public int collectedFlower;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collectedFlower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(collectedFlower);

        if (collectedFlower >= 5)
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            FindObjectOfType<LevelLoader>().MainUi();

        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpValues;
        }


        //moveLeftAndRight
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed ,rb.velocity.y);


        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, ground);
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumnpForce;
            extraJumps--;
            FindObjectOfType<AudioManager>().Play("Jump");
        

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {

            rb.velocity = Vector2.up * jumnpForce;
           
        }
            


        //ChngeSide
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;


    }
}
