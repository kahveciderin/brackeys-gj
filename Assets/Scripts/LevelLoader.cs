using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelLoader : MonoBehaviour
{

    public GameObject[] sprites;
    public Vector2 tileSize;
    public GameObject blocker;
    public GameObject background;

    [Space]
    [Header("Decorations")]
    public GameObject[] Decorations;
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
        


        GameObject left = Instantiate(Decorations[1], new Vector3(x - 1, y/2, -1), Quaternion.identity);
        left.transform.SetParent(gameObject.transform);
        left.transform.localPosition = new Vector3(-3.5f, 3,1);
        left.transform.localScale = new Vector2(left.transform.localScale.x, left.transform.localScale.y);

        GameObject right = Instantiate(Decorations[0], new Vector3(x - 1, y/2, -1), Quaternion.identity);
        right.transform.SetParent(gameObject.transform);
        right.transform.localPosition = new Vector3(level[0].Length+2.5f, 3,1);
        right.transform.localScale = new Vector2(-right.transform.localScale.x, right.transform.localScale.y);


        GameObject floor = Instantiate(Decorations[2], new Vector3(x - 1, y/2, -1), Quaternion.identity);
        floor.transform.SetParent(gameObject.transform);
        floor.transform.localPosition = new Vector3(level[0].Length / 2, -1.5f,1);
        floor.transform.localScale = new Vector2(  Mathf.Max(floor.transform.localScale.x, level[0].Length / (2 * tileSize.x)), floor.transform.localScale.y);
        

        GameObject block = Instantiate(blocker, new Vector3(x - 1, y/2, -1), Quaternion.identity);
        block.transform.SetParent(gameObject.transform);
        block.transform.localPosition = new Vector3(level[0].Length - 3, y/2 + 3,1);
        block.transform.localScale = new Vector2(1,y*10);


        background.transform.localScale = new Vector2(Mathf.Max(level[0].Length/ 2 + 3, 10), Mathf.Max(y + 3, 10));
        background.transform.localPosition = new Vector3(background.transform.localPosition.x, background.transform.localPosition.y + 0.5f, background.transform.localPosition.z);
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
