using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public TextMeshProUGUI value_time;
    public bool active = false;


    private void Start() {
       Time.timeScale = 0f;
    }

    void Update(){
        value_time.text = "" + (int) Time.time;

    }
}
