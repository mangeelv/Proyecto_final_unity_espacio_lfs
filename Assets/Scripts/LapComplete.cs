using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Asegúrate de usar TextMeshPro en lugar de UI.Text

public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalftLapTrig;

    public TMP_Text MinuteDisplay; // Usar TMP_Text para soporte TextMeshPro
    public TMP_Text SecondDisplay;
    public TMP_Text MilliDisplay;

    public TMP_Text LapCounter; // Cambiado a TMP_Text para LapCounter
    public int LapsDone;

    public float RawTime;

    public GameObject RaceFinish;

    public string MinSave;
    public string SecSave;
    public string MilliSave;
    public string RawTimeLoad;

    private void Update()
    {
        if (LapsDone == 1)
        {
            RaceFinish.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        // Verifica si el objeto que activó el trigger tiene la etiqueta "Player"
        if (collision.gameObject.tag == "Untagged")
        {
            LapsDone += 1;
            RawTime = PlayerPrefs.GetFloat(RawTimeLoad, 0); // Valor predeterminado 0 si no existe

            if (LapTimeManager.RawTime <= RawTime || RawTime == 0)
            {
                // Actualiza el texto de los segundos con formato adecuado
                if (LapTimeManager.SecondCount <= 9)
                {
                    SecondDisplay.text = "0" + LapTimeManager.SecondCount + ".";
                }
                else
                {
                    SecondDisplay.text = "" + LapTimeManager.SecondCount + ".";
                }

                // Actualiza el texto de los minutos con formato adecuado
                if (LapTimeManager.MinuteCount <= 9)
                {
                    MinuteDisplay.text = "0" + LapTimeManager.MinuteCount + ":";
                }
                else
                {
                    MinuteDisplay.text = "" + LapTimeManager.MinuteCount + ":";
                }

                // Actualiza el texto de los milisegundos
                MilliDisplay.text = LapTimeManager.MilliCount.ToString("F0");
            }

            // Guarda los tiempos usando PlayerPrefs
            PlayerPrefs.SetInt(MinSave, LapTimeManager.MinuteCount);
            PlayerPrefs.SetInt(SecSave, LapTimeManager.SecondCount);
            PlayerPrefs.SetFloat(MilliSave, LapTimeManager.MilliCount);
            PlayerPrefs.SetFloat(RawTimeLoad, LapTimeManager.RawTime);

            // Reinicia los contadores de tiempo
            LapTimeManager.MinuteCount = 0;
            LapTimeManager.SecondCount = 0;
            LapTimeManager.MilliCount = 0;
            LapTimeManager.RawTime = 0;

            // Actualiza el contador de vueltas
            LapCounter.text = LapsDone.ToString();

            // Cambia el estado de los triggers
            HalftLapTrig.SetActive(true);
            LapCompleteTrig.SetActive(false);
        }
    }
}
