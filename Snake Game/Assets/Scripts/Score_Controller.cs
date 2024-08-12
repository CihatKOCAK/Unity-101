using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Controller : MonoBehaviour
{
    // Start is called before the first frame update

   public Text scoreText;
   public Text highScoreText;
   public static int score = 0;
   public static int highScore = 0; 

    void Start()
    {
         score = 0;
         highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void Update()
    {
        if(score >= highScore){
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        
        //if score is have reference to the text component
        if(scoreText != null){
            scoreText.text = "Score: " + score;
        }
        if(highScoreText != null){
            highScoreText.text = "High Score: " + highScore;
        }
    }
}
