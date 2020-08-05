using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public GameObject gridLine;
    void Start()
    {
        for(int i = -30; i < 30; i++){
            GameObject line =Instantiate(gridLine, new Vector2(0,0), Quaternion.identity);
            line.transform.parent = gameObject.transform;
            line.transform.localPosition = new Vector2(i, 0);
            line.transform.localScale = new Vector2(0.1f, 30f);
        }

        for(int i = -30; i < 30; i++){
            GameObject line =Instantiate(gridLine, new Vector2(0,0), Quaternion.identity);
            line.transform.parent = gameObject.transform;
            line.transform.localPosition = new Vector2(0, i);
            line.transform.localScale = new Vector2(30f, 0.1f);
        }
    }

}
