using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //nie uwsuwaj menadzera gry po za³adowaniu poziomu
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
