using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void StartGame(){
        //gameObject.GetComponent<GameState>().active = true;
        Time.timeScale = 1f;

        gameObject.SetActive(false);
        //Destroy(gameObject);
   }

   public void GameOver(){
        SceneManager.LoadScene("SampleScene");
   }
}   
