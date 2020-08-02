using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFactory : MonoBehaviour
{
    int levelid = 0;
    public LevelLoader levelloader;
    public Camera camera;
    public PlayerController player;
    public int[][] traditionalLevels = new int[][]{


        new int[] {3,4,0,1,1,0,1,1,0,0,1,2,0,1},
        new int[] {4,3,0,1,1,0,0,1,1,0,0,1,1,2}

    };

    void Start(){
        levelloader.LoadLevel(levelloader.ConvertLevel(traditionalLevels[levelid]));
    }

    public void OnLevelEnd(){
        camera.LevelUp();
        player.ResetPlayer();
        levelid++;
        levelloader.LoadLevel(levelloader.ConvertLevel(traditionalLevels[levelid]));
    }
}
