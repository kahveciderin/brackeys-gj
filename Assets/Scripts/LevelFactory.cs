using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelFactory : MonoBehaviour
{
    int levelid = 0;
    public LevelLoader levelloader;
    public Camera camera;
    public BetterPlayerMovement player;

    public int useBlocks;
    public int last;
    public GameObject[] tuto;
    public GameObject[] tileMaps;

    public int[] dontUseBlocks;
    public int[][] traditionalLevels = new int[][]{

        

        
        new int[] {8, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 2, 4, 4, 4, 4, 4, 4, 4, 4, 4, },
        new int[] {8, 6, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 2, 4, 4, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, },
        new int[] {9, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 5, 0, 2, 4, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, },
        new int[] {9, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, -3, 0, 4, 0, 2, 4, 4, 0, 9, 0, 0, 4, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, },
        new int[] {11, 7, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 3, -3, 10, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 5, 0, 11, 0, 10, 0, 0, 0, 2, 4, 4, 0, 0, 0, 11, 0, 0, 0, 0, 0, 4, 4, 0, 0, 11, 0, 0, 11, 0, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, },

        new int[] {22, 16, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 10, 0, 0, -3, 0, 0, 4, 13, 0, 0, 0, 0, 0, 2, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, },
        new int[] {13, 6, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 5, 0, 0, 3, 10, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, -3, 0, 0, 2, 4, 4, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, },
        new int[] {7, 12, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 4, 4, 0, 10, 0, 0, 0, 4, 4, 0, -3, 0, 0, 0, 4, 4, 0, 3, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 4, 4, 0, 5, 0, 0, 0, 4, 4, 0, 5, 0, 0, 0, 4, 4, 0, 5, 0, 0, 0, 4, 4, 0, 0, 0, 0, 2, 4, 4, 4, 4, 4, 4, 4, 4, },




       
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
        PlayerPrefs.SetInt("levelToLoad", id);
        if(id < traditionalLevels.Length){

       levelloader.LoadLevel(levelloader.ConvertLevel(traditionalLevels[id]));
       }
       else{
            levelloader.LoadLevel(levelloader.ConvertLevel(GenerateLevel(id)));
       }

       if(id >= tuto.Length){
           foreach(GameObject t in tuto){

           t.SetActive(false);
           }
       }else{

            foreach (GameObject go in tileMaps)
                go.SetActive(false);
           tileMaps[id].SetActive(true);

           tuto[id].SetActive(true);
            foreach(GameObject t in tuto){

                if(t != tuto[id])
           t.SetActive(false);
           }
           
       }
    }

    int[] GenerateLevel(int seed){

        Random.seed = seed;
        int x = Random.Range(11,20);
        int y = Random.Range(8,13);
        int blockCnt = Random.Range((x * y ) / 15 - 1, (x * y ) / 15 + 7);
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
                    add = Random.Range(-useBlocks,useBlocks);
                }while(dontUseBlocks.Contains(Mathf.Abs(add)));

                if(Random.Range(0,14) == 0){
                    level.Add(-3);
                }else{


                if(Mathf.Abs(add) == useBlocks){
                    add = Random.Range(useBlocks, last);
                }
                level.Add(add);
                
                }
            }else{
                level.Add(0);
            }
        }
        return level.ToArray();
    }
}
