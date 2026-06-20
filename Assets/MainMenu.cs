using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Keluar Game");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
