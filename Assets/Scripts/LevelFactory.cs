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


        new int[] {3,4,0,3,1,0,3,1,0,3,1,3,2,1},
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
        //TODO: Add level generation code here
        return new int[2];
    }
}
