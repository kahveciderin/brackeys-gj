using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFactory : MonoBehaviour
{
    int levelid = 0;
    public LevelLoader levelloader;
    public Camera camera;
    public BetterPlayerMovement player;
    public int[][] traditionalLevels = new int[][]{


        new int[] {3,4,0,-3,1,0,3,1,0,3,1,3,2,1},
        new int[] {4,3,0,1,3,0,0,3,1,0,0,1,1,2}

    };

    void Start(){
        levelloader.LoadLevel(levelloader.ConvertLevel(traditionalLevels[levelid]));
    }

    public void OnLevelEnd(){
        camera.LevelUp();
        player.ResetPlayer();
        levelid++;

        if(levelid < traditionalLevels.Length){

        levelloader.LoadLevel(levelloader.ConvertLevel(traditionalLevels[levelid]));
        }
        else{
            levelloader.LoadLevel(levelloader.ConvertLevel(GenerateLevel(levelid)));
            
        }
    }


    int[] GenerateLevel(int seed){

        int x = 30;
        int y = 15;
        Random.seed = seed;
        
        
        int cntr = 1;
        bool isgoaladded = false;
        List<int> level = new List<int>();
        
        level.Add(x);
        level.Add(y);
        
        for(int i = 0; i < x * y; i++){

            if(i % x == 0 || i % x == x - 1 || i > y * x - x){
                level.Add(5);
            }else{
                if(Mathf.Round(Random.Range(0,cntr)) == 0 && Random.Range(0,1) == 0){
                cntr++;
                int add = 0;
                if(isgoaladded || i % x != x - 2){
                
                do{

                add = Random.Range(-6,6);
                }while(add == 2);
                }
                
                else{
                add = Random.Range(-6,6);
                if(add == 2)    isgoaladded = true;
                }

                level.Add(add);
                }
                else{
                level.Add(0);
                }
            }
        }
        //TODO: Add level generation code here
        return level.ToArray();
    }
}
