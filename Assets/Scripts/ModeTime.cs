using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Importa la biblioteca para TextMeshPro

public class ModeTime : MonoBehaviour
{
    public int ModeSelection;
    public GameObject position;
    public GameObject lapCounter;


    public GameObject AICar;
   



    public static bool isTimeMode = false;
    void Start()
    {
        ModeSelection = ModeSelect.RaceMode;

        if (ModeSelection == 2)
        {
            lapCounter.SetActive(false);
            position.SetActive(false);
            isTimeMode = true;
            AICar.SetActive(false);
        }
    }


}
