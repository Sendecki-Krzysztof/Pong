using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static int PlayerScore1 = 0;
    public static int PlayerScore2 = 0;
    public int winningScore = 10;
    private bool ispaused = false;

    public GUISkin layout;

    GameObject theBall;


    // Detects if teh call has hit the left or right wall and adds the score to the correct player
    public static void Score(string wallID)
    {
        if (wallID == "Right")
        {
            PlayerScore1++;
        }
        else if (wallID == "Left")
        {
            PlayerScore2++;
        }
    }

    private void quit() {
        Application.Quit();
    }
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        buttonHandler();
        checkScore();
    }

    // Method to handle the placement and initialization of new GUI buttons on the game board. 
    void buttonHandler() {
        if (GUI.Button(new Rect(Screen.width / 2 - 70, 10, 100, 40), "RESTART")) {
            handleRestart();
        }

        if (GUI.Button(new Rect(Screen.width / 2 + 31, 10, 60, 40), "QUIT")) {
            quit();
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 70, 51, 161, 30), "PAUSE")) {
            handlePauseGame();
        }

    }

    // Checks if either of the players have reached the winning score.
    void checkScore() {

        if (PlayerScore1 == winningScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("resetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == winningScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("resetBall", null, SendMessageOptions.RequireReceiver);
        }
    }


    // If the pause button or key have been pressed, checks if game is paused. If it is then it will be unpaused, if not 
    // then it will be paused.
    void handlePauseGame() {
        if (!ispaused)
        {
            Time.timeScale = 0;
            ispaused = true;
        }
        else if (ispaused)
        {
            Time.timeScale = 1;
            ispaused = false;
        }
    }

    // Handles the restarting of the game if the hotkey or button are pressed
    void handleRestart() {
        PlayerScore1 = 0;
        PlayerScore2 = 0;
        theBall.SendMessage("resetGame", 0.5f, SendMessageOptions.RequireReceiver);
    }

    // Checks if any hot keys have been pressed.
    void hotKeys() {
        if (Input.GetKey(KeyCode.R))
        {
            handleRestart();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            handlePauseGame();
        }

        if (Input.GetKey(KeyCode.Escape)){
            quit();
        } 
    }


    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }


    // Update is called once per frame
    void Update()
    {
        hotKeys();
    }
        
}
