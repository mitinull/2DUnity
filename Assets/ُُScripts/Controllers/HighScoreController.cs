using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, coinText;
    void Start()
    {
        SetScoreBasedOnDifficulty();
    }
    void SetScore(int score,int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }
    void SetScoreBasedOnDifficulty()
    {
        if(GamePreferences.GetEasyDifficultyState ()== 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighscore(), GamePreferences.GetEasyDifficultyCoinScore());
        }
        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighscore(), GamePreferences.GetMediumDifficultyCoinScore());
        }
        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighscore(), GamePreferences.GetHardDifficultyCoinScore());
        }

    }
    public void GoBackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

}
