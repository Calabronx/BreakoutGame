using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   public void Setup() {
    gameObject.SetActive(true);
   }

   public void Desactivate() {
      gameObject.SetActive(false);
   }

   public void RestartButton() {
      SceneManager.LoadScene("BrekaoutGame");
   }

   public void ExitButton() {
      // SceneManager.LoadScene("MainMenu");
      Application.Quit(0);
   }
}
