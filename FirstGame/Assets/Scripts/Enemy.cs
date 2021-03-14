using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float sickLevel;
    Transform cone;
    Vector3 targetScale;

    SpriteRenderer mask;

    bool hasMask = false;

    void Start()
    {
        sickLevel = 100;
        cone = transform.Find("sicknessCone");
        targetScale = cone.localScale;
        mask = transform.Find("maskPivot").GetComponentInChildren<SpriteRenderer>();
        mask.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(sickLevel <= 0) {
            Destroy(gameObject);
        }
        if(Vector3.Distance(cone.localScale, targetScale) > 0.05f) {
            cone.localScale = Vector3.Lerp(cone.localScale, targetScale, Time.deltaTime*2);
        }
    }

    public void damageTaken() {
        if(sickLevel == 60) {
            return;
        }

        sickLevel = sickLevel - 20f;
        // cone.localScale = new Vector3(sickLevel/100f, sickLevel/200f);

        targetScale = new Vector3(sickLevel/100f, sickLevel/200f);
    }

    public void placeMask() {
        if (hasMask) 
            return;
        
        targetScale = new Vector3(0, 0);
        mask.enabled = true;
        cone.GetComponentInChildren<SpriteRenderer>().enabled = false;
        hasMask = true;
        runAway();
    }

    void runAway() {
        return;
    }
}
