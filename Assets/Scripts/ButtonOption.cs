using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonOption : MonoBehaviour
{
    //public void PlayGame()
    //{
    // SceneManager.LoadScene(2);
    //}

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        ModeTime.isTimeMode = false; // asegurarse
        SceneManager.LoadScene(0);
    }

    // Below here are tack selection buttons

    public void Track01()
    {
        SceneManager.LoadScene(2);
    }

    public void Track02()
    {
        SceneManager.LoadScene(3);
    }

    public void CreditScene()
    {
        SceneManager.LoadScene(4);
    }

    // M�todo para realizar el reset
    public void MasterReset()
    {
        PlayerPrefs.DeleteAll(); // Elimina todos los PlayerPrefs
        PlayerPrefs.Save(); // Asegura que los cambios se guarden
    }

    public void CloseGame()
    {
       
        Application.Quit();
    }
}
