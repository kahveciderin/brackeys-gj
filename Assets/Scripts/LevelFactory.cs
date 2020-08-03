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


        new int[] {3,4,0,-3,1,0,3,1,0,3,1,3,2,1}
        //new int[] {4,3,0,1,3,0,0,3,1,0,0,1,1,2}

    };

    void Start(){
        levelid = PlayerPrefs.GetInt("levelToLoad");

       LoadLevel(levelid);
    }

    public void OnLevelEnd(){
        camera.LevelUp();
        player.ResetPlayer();
        levelid++;

       LoadLevel(levelid);
    }


    void LoadLevel(int id){
        if(id < traditionalLevels.Length){

       levelloader.LoadLevel(levelloader.ConvertLevel(traditionalLevels[id]));
       }
       else{
            levelloader.LoadLevel(levelloader.ConvertLevel(GenerateLevel(id)));
       }
    }

    int[] GenerateLevel(int seed){

        Random.seed = seed;
        int x = Random.Range(11,20);
        int y = Random.Range(8,13);
        int blockCnt = Random.Range((x * y ) / 15 - 1, (x * y ) / 15 + 3);
        List<int> blockpos = new List<int>();
        for(int i = 0; i < blockCnt; i++){
            blockpos.Add(Random.Range((x + 2),(x - 1) * (y - 1)));
            
        }
        int goalHeight = Random.Range(2, y-1);
        //Debug.Log(goalHeight);
        List<int> level = new List<int>();
        level.Add(x);
        level.Add(y);
        for(int i = 0; i < x * y; i++){
            if(i % x == 0 || i < x - 1 || i % x == x - 1 || i > y * x - x){
                level.Add(4);
            }else if((x - 1) * goalHeight + (goalHeight - 1) - 1== i){
                level.Add(2);
            }else if(blockpos.Contains(i)){

                int add = 0;
                do{
                    add = Random.Range(-6,6);
                }while(Mathf.Abs(add) == 2 || Mathf.Abs(add) == 0 || Mathf.Abs(add) == 4);

                if(Random.Range(0,3) == 0){
                    level.Add(-3);
                }else{

                level.Add(add);
                
                }
            }else{
                level.Add(0);
            }
        }
        return level.ToArray();
    }
}
