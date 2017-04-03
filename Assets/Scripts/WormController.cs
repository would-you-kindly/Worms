using UnityEngine;
using System.Collections;

public class WormController : MonoBehaviour
{
    public float move;
    public bool isOnGround = false;
    public float jumpForce = 175.0f;
    public bool facingRight = false;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float groundRadius = 0.2f;
    public float hitPoints = 100.0f;


    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }

        if (this.gameObject == MoveController.activeWorm)
        {
            // Прыжок
            if (isOnGround && Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jumpForce));
                GetComponent<Animator>().SetBool("takeBazuka", false);
            }

            if (isOnGround)
            {
                //GetComponent<Animator>().SetBool("isJump", false);
                // Передвижение

                move = Input.GetAxisRaw("Horizontal");
                if (move != 0)
                {
                    GetComponent<Animator>().Play("WormWalk");
                    GetComponent<Animator>().SetBool("takeBazuka", false);
                }
                else
                {
                    if (!GetComponent<Animator>().GetBool("takeBazuka"))
                    {
                        GetComponent<Animator>().Play("WormIdle");
                    }
                }
            }
            else
            {
                GetComponent<Animator>().Play("WormJump");
            }

            // Перемещаем червяка
            GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);

            // Разворачиваем персонажа
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        } // active worm
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "dieCollider")
        {
            Destroy(this.gameObject);
        }
        GetComponent<MoveController>().SetNextWormActive();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnGUI()
    {
        if (MoveController.activeWorm == gameObject)
        {
            GUI.Label(new Rect(50, 20, 100, 20), "Hit points: " + ((int)hitPoints).ToString());
        }
    }
}
