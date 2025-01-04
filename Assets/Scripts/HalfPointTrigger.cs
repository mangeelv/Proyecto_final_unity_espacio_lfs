using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPointTrigger : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    void OnTriggerEnter(Collider collision) // Cambiado para incluir el parámetro Collider
    {
        // Verifica si el objeto que activó el trigger tiene la etiqueta "Player"
        if (collision.gameObject.tag == "Untagged")
        {
            LapCompleteTrig.SetActive(true);
            HalfLapTrig.SetActive(false);
        }
    }
}
