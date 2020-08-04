using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{

    public bool spring;
    public bool deadly;
    
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Adult");
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject == player){

            if(spring)
            player.GetComponent<BetterPlayerMovement>().velocity.y = 10;
            if(deadly)
            player.GetComponent<BetterPlayerMovement>().ResetPlayer();
        }
    }
}
