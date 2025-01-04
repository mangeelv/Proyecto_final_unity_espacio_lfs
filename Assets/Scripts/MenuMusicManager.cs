using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    private void Awake()
    {
        // Si ya existe una instancia, destruye este objeto
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Asigna esta instancia y evita que se destruya entre escenas
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Escucha cambios de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Desuscribirse al destruir el objeto
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Verifica si la escena es diferente a 0 o 1
        if (scene.buildIndex != 0 && scene.buildIndex != 1 && scene.buildIndex != 4)
        {
            // Destruye el objeto para detener la música
            Destroy(gameObject);
        }
    }
}
