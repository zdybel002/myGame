using UnityEngine;
using UnityEngine.SceneManagement; // To jest konieczne do zmiany scen!

public class MainMenu : MonoBehaviour
{
    // Tê funkcjê podepnij pod przycisk "Graj" (Play)
    public void OnClickPlay()
    {
        // £aduje scenê z indeksem 1 (ustawion¹ w File -> Build Settings)
        SceneManager.LoadScene(1);
    }

    // Tê funkcjê podepnij pod przycisk "WyjdŸ" (Exit)
    public void OnClickExit()
    {
        Debug.Log("Wychodzenie z gry..."); // Komunikat dla Ciebie w edytorze
        Application.Quit(); // To zadzia³a dopiero po zbudowaniu gry (.exe)
    }
}