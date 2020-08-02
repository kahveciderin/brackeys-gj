using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    LevelFactory factory;

    void Start(){
        factory = GameObject.Find("LevelLoader").GetComponent<LevelFactory>();
    }
    void OnTriggerEnter2D(Collider2D col){
     if(col.gameObject.tag == "Player"){
         factory.OnLevelEnd();
     }
     
     }
}
