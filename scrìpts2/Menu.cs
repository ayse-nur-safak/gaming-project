using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("All Menu")]
    public GameObject PauseMenuUI;
    public GameObject EndGameUI;
    public GameObject ObjectiveMenuUI;
    public static bool GameISStopped=false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameISStopped) {
                resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pause();
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (Input.GetKeyDown("m"))
        {
            if (GameISStopped)
            {
                removeObjectives();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                showObjectives();
                Cursor.lockState= CursorLockMode.None;
            }
        }
    }
    public void showObjectives()
    {
        ObjectiveMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameISStopped = true;
    }
    public void removeObjectives()
    {
        ObjectiveMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameISStopped = false;
    }
    public void pause (){
        PauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameISStopped=true;

    }
    public void resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState= CursorLockMode.Locked;
        GameISStopped = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("mainmap");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}
