using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    /* 
    
    On click send to create/load save menu (SENDING TO TEST LEVEL FOR NOW)

    */
    {

        SceneManager.LoadScene("TestLevel");

    }

    public void Settings()
    /* 

    On click send to Settings

    */
    {

        SceneManager.LoadScene("Settings");

    }

    public void Quit()
    /* 

    On click send to Desktop

    */
    {

        Application.Quit();

    }

}
