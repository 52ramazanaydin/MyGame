
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;

    public GameObject pauseMenu_obj;

    public bool isGameOver = false;

    public GameObject player, pistol;

    public AudioSource music;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (!isGamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }

        }
    }
    private void Pause()
    {
        //Set Time Scale
        Time.timeScale = 0;

        //Pause the Music
        music.Pause();

        //Disable PlayerMovement and Pistol
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;

        //Set Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Pause Menu
        pauseMenu_obj.SetActive(true);

        //Set boolean
        isGamePaused = true;

    }
    private void Resume()
    {
        //Set Time Scale
        Time.timeScale = 1;

        //Resume the Music
        music.UnPause();

        //Set Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        //Enable PlayerMovement and Pistol
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;

        //Pause Menu
        pauseMenu_obj.SetActive(false);

        //Set boolean
        isGamePaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
