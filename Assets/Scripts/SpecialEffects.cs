using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialEffects : MonoBehaviour
{

    public bool spring;
    public bool deadly;
    public bool changeDir;
    
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
            SceneManager.LoadScene(1);
            if(changeDir){

                if(player.GetComponent<BetterPlayerMovement>().isBaby){
                player.GetComponent<BetterPlayerMovement>().direc = ! player.GetComponent<BetterPlayerMovement>().direc;
                }
            }
        }
    }
}
