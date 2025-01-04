using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceFinish : MonoBehaviour
{
    public GameObject Car; // Main car
    public List<GameObject> DreamCars; // List of secondary cars
    public GameObject FinishCam;
    public GameObject LevelMusic;
    public GameObject MainCamera;

    public GameObject CompleteTrig;

    private void OnTriggerEnter(Collider collision)

    {
       
        if (collision.gameObject.tag == "Untagged") {
            if (ModeTime.isTimeMode == true)
            {
                // we are on Race TIME mode
            }
            else
            {
                // Stop and freeze the main car
                StopAndFreezeCar(Car);

                // Deactivate all dream cars
                foreach (GameObject dreamCar in DreamCars)
                {
                    dreamCar.SetActive(false);
                }

                // Switch cameras
                FinishCam.SetActive(true);
                MainCamera.SetActive(false);

                // Optionally disable level music
                // LevelMusic.SetActive(false);

                // Disable the complete trigger
                CompleteTrig.SetActive(false);
            }
        }
    }

        

    private void StopAndFreezeCar(GameObject carObject)
    {
        Rigidbody carRb = carObject.GetComponent<Rigidbody>();
        if (carRb != null)
        {
            carRb.velocity = Vector3.zero; // Stop linear velocity
            carRb.angularVelocity = Vector3.zero; // Stop angular velocity

            // Freeze the position and rotation
            carRb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }

        // Disable car control script if available
        CarController carController = carObject.GetComponent<CarController>();
        if (carController != null)
        {
            carController.enabled = false;
        }
    }
}
