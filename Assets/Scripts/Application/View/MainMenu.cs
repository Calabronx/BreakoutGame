using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject game;
    [SerializeField] GameObject brickInitializer;
    [SerializeField] GameObject brick;
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public void start()
    {
        //   gameObject.SetActive(false);
        game.SetActive(true);
        ball.SetActive(true);
        brick.SetActive(true);
        brickInitializer.SetActive(true);
        gameObject.SetActive(false);
        //   SceneManager.LoadScene("BrekaoutGame");
    }

    public void ExitButton()
    {
        // SceneManager.LoadScene("MainMenu");
        Application.Quit(0);
    }

}
