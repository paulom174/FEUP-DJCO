using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OrderLayer : MonoBehaviour
{
    private TilemapRenderer rend;
    public Rigidbody2D player_rb;

    void Start()
    {
        rend = gameObject.GetComponent<TilemapRenderer>();

    }
    void Update()
    {
        if(player_rb != null && player_rb.transform.localPosition.y > 8.45){
            rend.sortingOrder = 1;//front player
        }else{
            rend.sortingOrder = -1;//behind player
        }
    }
}
