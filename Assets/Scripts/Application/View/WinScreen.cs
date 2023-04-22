using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
     [SerializeField] GameObject menu;
    // [SerializeField] GameObject game;
    // [SerializeField] GameObject brickInitializer;
    // [SerializeField] GameObject brick;
   public void Setup()
    {
        gameObject.SetActive(true);
        // game.SetActive(false);
        // ball.SetActive(false);
        // brick.SetActive(false);
        // brickInitializer.SetActive(false);
        // gameObject.SetActive(false);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public void ReturnMenu() {
    //   SceneManager.LoadScene("BrekaoutGame");
        gameObject.SetActive(false);
        menu.SetActive(true);
   }

    public void ExitButton()
    {
        // SceneManager.LoadScene("MainMenu");
        Application.Quit(0);
    }
}
