using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private void Start() {
       Time.timeScale = 0f;
    }
    public bool active = false;
}
