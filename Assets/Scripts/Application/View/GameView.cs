using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameView : MonoBehaviour
{
    public string lifesScore = "Lifes:";
    public string continueGameMsg = "Continuar? Presione click izquierdo";
    public string restartGameQuestionMsg = "Presione la tecla Enter para continuar o Escape para salir";

    public string totalPointsMsg = "Total points: ";
    public string totalBricksDestroyedMsg = "Total bricks destroyed: ";
    public TMP_Text lifesText;
    public TMP_Text loseMessage;
    public TMP_Text winMessage;
    public TMP_Text continueMessageView;
    public TMP_Text restartGameQuestion;
    public TMP_Text totalPoints;
    public TMP_Text totalBricksDestroyed;
    

    public enum GameMessagesStatus {
        // set messages for game
    }
    
}
