using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameView : MonoBehaviour
{
    public string lifesScore = "Lifes:";
    public string continueGameMsg = "Continuar? Presione click derecho";
    public TMP_Text lifesText;
    public TMP_Text loseMessage;
    public TMP_Text winMessage;
    public TMP_Text continueMessageView;
    

    public enum GameMessagesStatus {
        // set messages for game
    }
    
}
