using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa la biblioteca para TextMeshPro

public class ModeScore : MonoBehaviour
{
    public int ModeSelection;
    public GameObject RaceUI;
    public GameObject ScoreUI;
    public GameObject AICar;
    public static int CurrentScore;
    public int InternalScore;

    public TextMeshProUGUI ScoreValue;
    public GameObject ScoreObjects;
    public GameObject position;
    void Start()
    {
        ModeSelection = ModeSelect.RaceMode;

        if (ModeSelection == 1)
        {
            position.SetActive(false);
            RaceUI.SetActive(false);
            ScoreUI.SetActive(true);
            AICar.SetActive(false);
            ScoreObjects.SetActive(true);
        }
    }

    void Update()
    {
        InternalScore = CurrentScore;
        ScoreValue.text = InternalScore.ToString(); 
    }
}
