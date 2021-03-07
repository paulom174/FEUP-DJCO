using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHighlight : MonoBehaviour
{
    public float alpha = 50;
    public int maxAlpha = 255;

    public float alphaSpeed = 50;

    private Color tmp;

    private SpriteRenderer m_SpriteRenderer;

    void Start() {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        tmp = m_SpriteRenderer.color;


    }

    // Update is called once per frame
    void Update()
    {
        if(alpha < 10 || alpha > 240) {
            alphaSpeed *= -1;
        }

        alpha = Mathf.Clamp(alpha, 0, maxAlpha);

        alpha += alphaSpeed * Time.deltaTime;

        tmp.a = alpha;

        m_SpriteRenderer.color = tmp;
    }
}
