using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadLapTime : MonoBehaviour
{
    public int MinCount;
    public int SecCount;
    public float MilliCount;
    public TextMeshProUGUI MinDisplay;
    public TextMeshProUGUI SecDisplay;
    public TextMeshProUGUI MilliDisplay;

    public string MinSave;
    public string SecSave;
    public string MilliSave;

    void Start()
    {
        MinCount = PlayerPrefs.GetInt(MinSave);
        SecCount = PlayerPrefs.GetInt(SecSave);
        MilliCount = PlayerPrefs.GetFloat(MilliSave);

        MinDisplay.text = MinCount.ToString("00") + ":";
        SecDisplay.text = SecCount.ToString("00") + ".";
        MilliDisplay.text = MilliCount.ToString("F0"); // Ajusta el formato según necesites (e.g., F0 para enteros o F2 para 2 decimales)
    }
}
