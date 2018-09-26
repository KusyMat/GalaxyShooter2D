using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadSinglePlayerGame()
    {
        Debug.Log("SinglePlayer is loading...");
        SceneManager.LoadScene("Single_Player", LoadSceneMode.Single);
    }

    public void LoadCoopModeGame()
    {
        Debug.Log("Co-op Mode is loading...");
        SceneManager.LoadScene("Coop_Mode", LoadSceneMode.Single);
    }
}
