using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuCalls : MonoBehaviour
{
    public Player p;  

    public void StartGame(){
      Time.timeScale = 1f;
      gameObject.SetActive(false); 
      p.GetComponent<ShooterControl>().enabled = true;
      p.GetComponent<Movement>().enabled = true;
    }

    public void GameOver(){
      SceneManager.LoadScene("SampleScene");
    }

}   
