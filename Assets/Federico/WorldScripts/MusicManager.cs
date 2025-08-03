using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    int buildIndex;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;

        if (buildIndex == 0 || buildIndex == 8)
        {
            gameObject.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = 0.2f;
        }
    }
}
