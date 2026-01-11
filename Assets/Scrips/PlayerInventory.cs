using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public int coinsCount;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            coinsCount++;
            Debug.Log("ilosc monet = " + coinsCount);
            Destroy(col.gameObject);
        }

       
    }
        


}
