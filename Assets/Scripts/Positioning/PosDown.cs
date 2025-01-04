using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PosDown : MonoBehaviour
{
    public TMP_Text positionDisplay;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CarPos"))
        {
            positionDisplay.text = "2nd Place";
        }
    }
}

