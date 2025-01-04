using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PosUp : MonoBehaviour
{
    public TMP_Text positionDisplay;

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CarPos"))
        {
            positionDisplay.text = "1st Place";
        }
    }
}
