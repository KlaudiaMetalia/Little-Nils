using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;
    public Text scoreText;
    private bool isDead = false;

    public LoseMenu loseMenu;

    // Update is called once per frame
    void Update () {

        if (isDead)
        {
            return;
        }
        
        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }
        //score += Time.deltaTime * difficultyLevel;
        //scoreText.text = ((int)score).ToString();

    }

    void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
            return;
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
        //Debug.Log(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        if((int)PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore",score);
        }
        
        loseMenu.ToggleEndMenu(score);
    }

    public void setScore(float vl)
    {
        score += vl;
        scoreText.text = ((int)score).ToString();
    }
}
