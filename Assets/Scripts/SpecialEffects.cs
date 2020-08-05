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
    Camera cam;
    GameObject particle;
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GameObject.Find("Adult");
        particle = player.GetComponent<BetterPlayerMovement>().deathParticle;
    }

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.gameObject == player){

            if(spring)
            player.GetComponent<BetterPlayerMovement>().velocity.y = 10;
            if(deadly){
                //player.GetComponent<BetterPlayerMovement>().ResetPlayer();

                particle.SetActive(true);
                player.GetComponent<BetterPlayerMovement>().stop = true;
                StartCoroutine(ResetGame());
            }
            //SceneManager.LoadScene(1);
            if(changeDir){

                if(player.GetComponent<BetterPlayerMovement>().isBaby){
                player.GetComponent<BetterPlayerMovement>().direc = ! player.GetComponent<BetterPlayerMovement>().direc;
                }
            }
        }
    }


    void OnTriggerStay2D(Collider2D coll){
        if(coll.gameObject == player){

            if(spring)
            player.GetComponent<BetterPlayerMovement>().velocity.y = 10;
        }
    }

    IEnumerator ResetGame(){
        cam.shake = true;
        yield return new WaitForSeconds(.1f);
        cam.shake = false;
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(1);
    }
}
