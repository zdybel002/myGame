using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour {

    [SerializeField] private Image health;
    private float healthValue;

    private Pllayer player;

    void Start()
    {
        player = FindFirstObjectByType<Pllayer>();


    }

    void Update()
    {
        health.fillAmount = player.Health.CurrentHealth / 100.0f;
    }


     


    
}
