using UnityEngine;

public class EnemyPAtrol : MonoBehaviour 
{


    public GameObject leftBorder;
    public GameObject rightBorder;
    public Rigidbody2D rigitbody;
    public GraundDetaction graundDetaction;

    public bool isRightDirection;

    public float speed = 1;
    [SerializeField] private SpriteRenderer spriteRenderer;

  
    private void Update()
    {
        if (isRightDirection && graundDetaction.isGrounded)   
        {
            rigitbody.linearVelocity = Vector2.right * speed;
            if(transform.position.x > rightBorder.transform.position.x)
            {
                isRightDirection = !isRightDirection;
            }


        }
        else if(graundDetaction.isGrounded)
        {
            rigitbody.linearVelocity = Vector2.left * speed;
            if (transform.position.x < leftBorder.transform.position.x)
            {
                isRightDirection = !isRightDirection;
            }
        }

        if (rigitbody.linearVelocity.x > 0)
            spriteRenderer.flipX = false;
        if (rigitbody.linearVelocity.x < 0)
            spriteRenderer.flipX = true;

    }
}
