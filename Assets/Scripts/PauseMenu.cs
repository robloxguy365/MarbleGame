using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        paused = false;
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();
        }
        SceneManager.LoadScene("Level Menu");
    }
}
