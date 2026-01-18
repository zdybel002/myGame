using UnityEngine;
using UnityEngine.SceneManagement; // <--- 1. To jest niezbêdne do zmiany sceny!

public class GameManager : MonoBehaviour
{
    // Zmienna do panelu pauzy
    public GameObject pausePanel;

    // Funkcja do PAUZOWANIA (pod przycisk Pauzy i Wznów)
    public void OnCLickPause()
    {
        if (Time.timeScale > 0)
        {
            // PAUZA
            Time.timeScale = 0;

            if (pausePanel != null)
            {
                pausePanel.SetActive(true);
            }
        }
        else
        {
            // WZNOWIENIE
            Time.timeScale = 1;

            if (pausePanel != null)
            {
                pausePanel.SetActive(false);
            }
        }
    }

    // 2. NOWA FUNKCJA: Powrót do Menu (pod przycisk "Menu" w panelu pauzy)
    public void GoToMainMenu()
    {
        // BARDZO WA¯NE: Zanim wyjdziesz, musisz "odmroziæ" czas!
        // Inaczej po powrocie do gry wszystko bêdzie nadal sta³o w miejscu.
        Time.timeScale = 1;

        // £adujemy scenê o indeksie 0 (zak³adamy, ¿e Menu to scena 0 w Build Settings)
        SceneManager.LoadScene(0);
    }
}