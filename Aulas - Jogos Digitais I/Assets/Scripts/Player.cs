using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 initialPosition;
    public GameManager gameManager;


    public Animator anim;
    private Rigidbody2D rigd;
    public float movespeed;

    public float jumpForce = 5f;
    public bool isGround;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigd = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Pega posição inicial
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    public void RestartPosition()
    {
        transform.position = initialPosition;
    }

    void Move()
    {
        float teclas = Input.GetAxis("Horizontal");
        rigd.linearVelocity = new Vector2(teclas * movespeed, rigd.linearVelocity.y);

        if (teclas > 0 && isGround == true)
        {   // Andar pra direita
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transition", 1);
        }

        if (teclas < 0 && isGround == true)
        {   // Andar pra esquerda
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transition", 1);
        }

        if (teclas == 0 && isGround == true)
        {   // Ficar parado
            anim.SetInteger("transition", 0);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rigd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetInteger("transition", 2);
            isGround = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tagGround")
        {
            isGround = true;
        }

        if (collision.gameObject.tag == "DeathBarrier")
        {
            GameObject player = GameObject.FindWithTag("Player");
            player.GetComponent<Player>().RestartPosition();

            gameManager.AlterLife(3);
        }

    }
}
