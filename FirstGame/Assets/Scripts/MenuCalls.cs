using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCalls : MonoBehaviour
{
    public void StartGameButton(){
      gameObject.SetActive(false); 
      FindObjectOfType<GameState>().PlayerRevive();
    }

    public void RetryGameButton(){
      SceneManager.LoadScene("SampleScene");
    }

    public void QuitGameButton(){
      Application.Quit();
    }
}   
