using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    void OnTriggerEnter()
    {
        ModeScore.CurrentScore += 1;
        gameObject.SetActive(false);
    }
}
