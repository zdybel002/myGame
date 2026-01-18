using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{

    public int coinsCount;
    [SerializeField] private Text coinsText;

    private void Start()
    {
        coinsText.text = "Iloœæ monet: 0";
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            coinsCount++;
            coinsText.text = "Iloœæ monet: " + coinsCount;
            Debug.Log("ilosc monet = " + coinsCount);
            Destroy(col.gameObject);
        }

       
    }
        


}
