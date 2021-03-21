using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float sickLevel;
    Transform cone;
    Vector3 targetScale;
    float startHeight;
    Color tmp;

    SpriteRenderer mask;

    bool hasMask = false;
    bool exitAnim = false;
    SpriteRenderer sRenderer;
    public float speedAnimExit = 1f;

    public Player p;

    void Start()
    {
        sickLevel = 100;
        cone = transform.Find("sicknessCone");
        targetScale = cone.localScale;
        mask = transform.Find("maskPivot").GetComponentInChildren<SpriteRenderer>();
        mask.enabled = false;
        startHeight = transform.localPosition.y;
        sRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(cone.localScale, targetScale) > 0.05f) {
            cone.localScale = Vector3.Lerp(cone.localScale, targetScale, Time.deltaTime*2);
        }
        if(exitAnim) {
            sRenderer.color = Color.Lerp(sRenderer.color, new Color(0,0,0,0), Time.deltaTime * speedAnimExit);
            mask.color = Color.Lerp(mask.color, new Color(0,0,0,0), Time.deltaTime * speedAnimExit);
        }
    }

    public void damageTaken() {
        if(sickLevel == 60) {
            return;
        }

        sickLevel = sickLevel - 20f;
        // cone.localScale = new Vector3(sickLevel/100f, sickLevel/200f);

        targetScale = new Vector3(sickLevel/100f, sickLevel/200f);
        FindObjectOfType<GameState>().addScore(5);
    }

    public void placeMask() {
        if (hasMask) 
            return;
        
        targetScale = new Vector3(0, 0);
        mask.enabled = true;
        cone.GetComponentInChildren<SpriteRenderer>().enabled = false;
        hasMask = true;
        GetComponent<EnemyMovement>().runAway();
    }

    public bool HasMask() {
        return hasMask;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "EnemyExit" && hasMask) {
            Destroy(gameObject, 1.3f);
            exitAnim = true;
        }
    }


}
