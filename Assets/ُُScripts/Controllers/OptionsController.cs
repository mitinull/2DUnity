using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject easysign, mediumsign, hardsign;
    void Start()
    {
        SetTheDifficulty();
    }
    void SetInitialDifficulty(string difficulty)
    {
        switch(difficulty)
        {
            case "Easy":
                mediumsign.SetActive(false);
                hardsign.SetActive(false);
                break;
            case "Medium":
                easysign.SetActive(false);
                hardsign.SetActive(false);
                break;

            case "Hard":
                easysign.SetActive(false);
                mediumsign.SetActive(false);
                break;

        }
    }
    void SetTheDifficulty()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetInitialDifficulty("Easy");
        }
        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetInitialDifficulty("Medium");
        }
        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetInitialDifficulty("Hard");
        }
    }

    public void EasyDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(1);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(0);
        easysign.SetActive(true);
        mediumsign.SetActive(false);
        hardsign.SetActive(false);
    }
    public void MediumDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(1);
        GamePreferences.SetHardDifficultyState(0);
        easysign.SetActive(false);
        mediumsign.SetActive(true);
        hardsign.SetActive(false);
    }
    public void HardDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(1);
        easysign.SetActive(false);
        mediumsign.SetActive(false);
        hardsign.SetActive(true);
    }
    // Update is called once per frame
    public void GoBackToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
