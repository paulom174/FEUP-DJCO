using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameState : MonoBehaviour
{
    public MenuCalls gameOverCanvas; 
    public TextMeshProUGUI value_score;
    public TextMeshProUGUI value_time;

    private Player p;
    private float score;
    private float startTime;

    public void Start(){
        // Freeze time: animations and everything affected by time stop, but for example Update() functions in scripts dont are
        Time.timeScale = 0f;

        // Find Player in the scene
        p = FindObjectOfType<Player>();

        // Player starts with all of its scripts disabled to no be able to move and shoot
        p.GetComponent<ShooterControl>().enabled = false;
        p.GetComponent<Movement>().enabled = false;

        // Reset time and score
        startTime = Time.time;
        score = 0;

    }

    public void PlayerDied(){
        // Put Player with dead state: this will trigger the death animation and restrict player movement and shooter again
        p.isDead = true;
        p.GetComponent<ShooterControl>().enabled = false;
        p.GetComponent<Movement>().enabled = false;

        // Active Game Over menu canvas
        gameOverCanvas.gameObject.SetActive(true);

    }

    public void PlayerRevive(){
        // Game starts and so as time
        Time.timeScale = 1f;

        // Player able to move and shoot scripts
        p.GetComponent<ShooterControl>().enabled = true;
        p.GetComponent<Movement>().enabled = true;

    }

    public void addScore(float value){
        score += value;
    }

    private void Update() {
        value_score.text = "score: " + Mathf.Clamp( score, 0, 10000).ToString("0.00");
        if(!p.isDead) value_time.text = Mathf.Clamp( Time.time - startTime, 0, 1000).ToString("0.00");
    }


}
