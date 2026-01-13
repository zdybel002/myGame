using UnityEngine;

public class Pllayer : MonoBehaviour
{
    public float speed = 6f;
    public float force = 5f;
    public Rigidbody2D rigidbody;

    public bool isCheatMode;
    public float minimalHeight;

    public GraundDetaction graundDetaction;

    private Vector3 direction;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool isJumping;

    // 1. Nowa zmienna pomocnicza
    private bool jumpRequest = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // 2. Dodajemy Update tylko do ³apania klawisza
    void Update()
    {
        // £apiemy wciœniêcie spacji w KA¯DEJ klatce
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {

        animator.SetBool("isGrounded", graundDetaction.isGrounded);

        // Jesli nie skaczemy i nie jestesmy na ziemi UPADAMY
        if (!isJumping && !graundDetaction.isGrounded)
            animator.SetTrigger("StartFall");

        // Resetujemy flagê skoku, jeœli dotknêliœmy ziemi
        if (graundDetaction.isGrounded)
            isJumping = false;

        direction = Vector3.zero;

        // Ma³a poprawka A+D (¿eby postaæ sta³a, gdy wciœniesz oba)
        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        direction *= speed;

        // Poprawka sk³adni dla Unity 6 (linearVelocity.y)
        direction.y = rigidbody.linearVelocity.y;
        rigidbody.linearVelocity = direction;

        // 3. Sprawdzamy nasz¹ zmienn¹ jumpRequest zamiast Input.GetKeyDown
        if (jumpRequest)
        {
            if (graundDetaction.isGrounded)
            {
                // Zerujemy prêdkoœæ Y przed skokiem, ¿eby skok by³ zawsze równy
                rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 0);

                rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                animator.SetTrigger("StartJump");
                isJumping = true;
            }
            // "Zu¿ywamy" proœbê o skok (¿eby nie skaka³ w nieskoñczonoœæ)
            jumpRequest = false;
        }

        // Zmiana kierunku chodzenia    
        if (direction.x > 0)
            spriteRenderer.flipX = false;
        if (direction.x < 0)
            spriteRenderer.flipX = true;

        animator.SetFloat("Speed", Mathf.Abs(direction.x));

        CheckFall();
    }

    void CheckFall()
    {
        if (transform.position.y < minimalHeight && isCheatMode)
        {
            rigidbody.linearVelocity = Vector2.zero;
            transform.position = Vector2.zero;
        }
        else if (transform.position.y < minimalHeight && !isCheatMode)
        {
            Destroy(gameObject);
        }
    }
}