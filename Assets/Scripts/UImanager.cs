using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

    // Interface Attribute
    public GameObject hudPanel;
    public GameObject resultPanel;

    //HUD
    public Text scoreText;
    private int score;

    //RESULT
    public Text Cur_scoreText;
    public Text Best_scoreText;

    // Increase score by 1
    public void Inc_score()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    // Show the GameOver UI
    public void ShowResult()
    {
        hudPanel.SetActive(false);
        resultPanel.SetActive(true);

        Cur_scoreText.text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        Best_scoreText.text = bestScore.ToString();

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }

    // Button event (Play again)
    public void OnRePlayClick()
    {
        int level = Application.loadedLevel;
        Application.LoadLevel(level);
    }

}
