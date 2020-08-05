using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject camera;
    public GameObject[] parallaxBg;
    public float moveDistance;
    
    void Update()
    {
        Vector2 distance = new Vector2(0 - camera.transform.position.x, 0 - camera.transform.position.y);

        for(int i = 0; i < parallaxBg.Length; i++){
            parallaxBg[i].transform.position = distance * new Vector2(i * moveDistance ,i * moveDistance);
        }
    }
}
