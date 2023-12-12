using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    // var to store player score
    public int playerScore;
    // reference to the Text gameobject
    public Text scoreText;
    // reference to the Text gameobject for the final score
    public Text finalScoreText;
    // reference to gameover gameobject 
    public GameObject gameOverScreen;

    // flag to check if game is over
    public bool isGameOver = false;
    public AudioSource increaseScoreSoundEffect;

    //context menu enables us to run this function inside unity
    // In Unity when the game is running, choose the function from the 3 dots
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        // if the game is not over, play sound effect then incrementing the score and then display it on UI
        if(!isGameOver){
            increaseScoreSoundEffect.Play();
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
        }
        
    }

    // method to restart the game/scene
    // to restart scene add import/add UnityEngine.SceneManagement
    public void restartGame()
    {
        // call up the sceneManager and load scene
        // this takes the file name of the scene you want to load
        // but since for our case we are only looking to load the current scene, here is the syntax
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // gameover logic
    // this function should be triggered when the bird crushes into a pipe
    public void gameOver()
    {
        // set the game over flag to true
        isGameOver = true;

        // display final score on game over screen
        finalScoreText.text = "Final Score: " + playerScore;

        // display the game over screen
        gameOverScreen.SetActive(true);

    }
}
