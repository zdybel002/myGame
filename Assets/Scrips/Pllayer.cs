using UnityEngine;

public class Pllayer : MonoBehaviour 
{

    public float speed = 6f;
    public float force = 5f;
    public Rigidbody2D rigidbody;

    public bool isCheatMode;
    public float minimalHeight;

    public GraundDetaction graundDetaction;

    void Update() {
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
           

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);


        }

        if (Input.GetKeyDown(KeyCode.Space) && graundDetaction.isGrounded){
            rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }


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
