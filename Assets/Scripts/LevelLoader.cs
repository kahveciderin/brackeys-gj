using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelLoader : MonoBehaviour
{

    public GameObject[] sprites;
    public Vector2 tileSize;

    public void LoadLevel(int[][] level){
             foreach (Transform child in transform)
         {
             Destroy(child.gameObject);
         }

        int x = 0, y = 0;
         foreach(int[] vtiles in level){
             foreach (int tile in vtiles){
                 
                GameObject thistile = Instantiate(sprites[Mathf.Abs(tile)], new Vector2(x, y), Quaternion.identity);
                
                thistile.transform.SetParent(gameObject.transform);
                
                thistile.transform.localPosition = new Vector2(x, y);
                thistile.transform.localScale = tileSize * new Vector2(tile< 0 ? -1 :1 ,1);
                x += 1;
             }
             x = 0;
             y += 1;
         }
    }

    public int[][] ConvertLevel(int[] data){
        int i = 0;
        int x = data[i];
        i++;
        int y = data[i];
        i++;
        List<int[]> final = new List<int[]>();
        for(int j = 0; j < y ; j++){
            List<int> thisrow = new List<int>();
            for(i = 2; i < x + 2; i++){
                thisrow.Add(data[i + j * x]);
            }
            final.Add(thisrow.ToArray());

        }

        return final.ToArray();
    }

    void Start(){
        //int[] startLevel = new int[] {4,3,0,1,1,0,0,1,1,0,0,1,1,1};
        //LoadLevel(ConvertLevel(startLevel));
    }
}
