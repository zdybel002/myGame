using UnityEngine;

public class ColisionDamage : MonoBehaviour
{

    public int damage = 10;
    [SerializeField] private Animator animator;
    private Health health;
    private float direction;    


    private void OnCollisionStay2D(Collision2D col)
    {
        health = col.gameObject.GetComponent<Health>();
        if (health != null)
        {
            direction = (col.transform.position - transform.position).x;
            animator.SetFloat("Direction", Mathf.Abs(direction));
        }
           
    }

    public void SetDamage()
    {

        if(health != null)
            health.TakeHit(damage);

        health = null;
        animator.SetFloat("Direction", 0f);
    }
    
}
