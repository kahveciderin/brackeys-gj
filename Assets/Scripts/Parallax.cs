using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject camera;
    public GameObject[] parallaxBg;
    public float moveDistance;
    

    public Vector2 offset;
    void Update()
    {
        Vector2 distance = new Vector2(0 - camera.transform.position.x, 0 - camera.transform.position.y);

        for(int i = 0; i < parallaxBg.Length; i++){
            parallaxBg[i].transform.localPosition = distance * new Vector2((parallaxBg.Length - i) * moveDistance ,(parallaxBg.Length - i) * moveDistance) + offset;
        }
    }
}
