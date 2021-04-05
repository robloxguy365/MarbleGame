using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishPad : MonoBehaviour
{
    public Text winText;
    private bool winning;
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("GameVolume");

        winning = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if(collision.gameObject.GetComponent<BallController>().count == collision.gameObject.GetComponent<BallController>().numPickups && !winning)
            {
                winText.text = "You Win!\nReturning to menu in 5 seconds";
                gameObject.GetComponent<AudioSource>().Play();
                Invoke(nameof(GoBackToMenu), 5.0f);
                winning = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
    }
    private void GoBackToMenu()
    {
        SceneManager.LoadScene("Level Menu");
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();
        }

    }
}
