using UnityEngine;

public class ColisionDamage : MonoBehaviour
{

    public int damage = 10;
    public string collisionTag;


    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log(col.gameObject.name);
        if(col.gameObject.CompareTag(collisionTag))
        {
            Health health = col.gameObject.GetComponent<Health>();
            health.TakeHit(damage);

        }

    }
    
}
