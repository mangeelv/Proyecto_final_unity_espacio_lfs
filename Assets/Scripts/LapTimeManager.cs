using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapTimeManager : MonoBehaviour
{
    public static int MinuteCount;
    public static int SecondCount;
    public static float MilliCount;
    public static string MilliDisplay;

    public TMP_Text MinuteBox;
    public TMP_Text SecondBox;
    public TMP_Text MilliBox;

    public static float RawTime;

    void Update()
    {
        MilliCount += Time.deltaTime * 10;
        RawTime += Time.deltaTime;
        MilliDisplay = MilliCount.ToString("F0");

        // Aquí verifica si los campos están asignados.
        if (MilliBox != null)
        {
            MilliBox.text = MilliDisplay;
        }
        else
        {
            Debug.LogError("MilliBox no está asignado.");
        }

        if (MilliCount >= 10)
        {
            MilliCount = 0;
            SecondCount += 1;
        }

        if (SecondBox != null)
        {
            if (SecondCount <= 9)
            {
                SecondBox.text = "0" + SecondCount + ".";
            }
            else
            {
                SecondBox.text = "" + SecondCount + ".";
            }
        }
        else
        {
            Debug.LogError("SecondBox no está asignado.");
        }

        if (SecondCount >= 60)
        {
            SecondCount = 0;
            MinuteCount += 1;
        }

        if (MinuteBox != null)
        {
            if (MinuteCount <= 9)
            {
                MinuteBox.text = "0" + MinuteCount + ":";
            }
            else
            {
                MinuteBox.text = "" + MinuteCount + ":";
            }
        }
        else
        {
            Debug.LogError("MinuteBox no está asignado.");
        }
    }
}
