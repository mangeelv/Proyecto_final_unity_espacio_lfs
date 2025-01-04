using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI CountDown;
    public AudioSource GetReady;
    public AudioSource GoAudio;
    public GameObject LapTimer;
    public GameObject CarControls;
    public AudioSource[] LevelMusicList; // Lista de canciones
    private AudioSource currentMusic; // Canción actual
    private int lastIndex = -1; // Índice de la última canción reproducida

    void Start()
    {
        StartCoroutine(CountStart());
    }

    void Update()
    {
        // Revisa si la canción actual ha terminado y selecciona una nueva
        if (currentMusic != null && !currentMusic.isPlaying)
        {
            PlayNextRandomMusic();
        }
    }

    void PlayNextRandomMusic()
    {
        if (LevelMusicList.Length == 0)
        {
            Debug.LogWarning("No hay canciones en la lista.");
            return;
        }

        int newIndex;
        do
        {
            newIndex = Random.Range(0, LevelMusicList.Length); // Selecciona un índice aleatorio
        } while (newIndex == lastIndex); // Asegúrate de que sea diferente al anterior

        lastIndex = newIndex; // Actualiza el índice de la última canción reproducida
        currentMusic = LevelMusicList[newIndex]; // Asigna la nueva canción
        currentMusic.Play(); // Reproduce la canción
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        CountDown.text = "3";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);

        CountDown.text = "2";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);

        CountDown.text = "1";
        GetReady.Play();
        CountDown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);

        CountDown.text = "GO!";
        GoAudio.Play();
        CountDown.gameObject.SetActive(true);

        // Comienza la música aleatoria
        PlayNextRandomMusic();

        yield return new WaitForSeconds(1);
        CountDown.gameObject.SetActive(false);

        LapTimer.SetActive(true);
        CarControls.SetActive(true);
    }
}
