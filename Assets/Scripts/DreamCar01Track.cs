using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCar01Track : MonoBehaviour
{
    public GameObject TheMarker;
    public GameObject[] Marks; // Arreglo para almacenar los 50 marks
    public int MarkTracker;

    void Update()
    {
        // Asegúrate de que el marcador esté dentro del rango del arreglo
        if (MarkTracker >= 0 && MarkTracker < Marks.Length)
        {
            TheMarker.transform.position = Marks[MarkTracker].transform.position;
        }
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dreamcar01")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            MarkTracker += 1;

            // Si llegamos al último marcador, reinicia el contador
            if (MarkTracker >= Marks.Length)
            {
                MarkTracker = 0;
            }

            yield return new WaitForSeconds(0.2f);
            this.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
