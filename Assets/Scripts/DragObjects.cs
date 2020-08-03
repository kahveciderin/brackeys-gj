using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{

    private bool isDragging;
    private float reachable;
    GameObject player;


    void Start(){
        player = GameObject.Find("Adult");
    }
    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {

            Vector2 mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (isDragging) {
            //reachable = true;

            reachable = Vector3.Distance(gameObject.transform.position, player.transform.position);
            //Debug.Log(reachable);
            if(reachable < 4){
            transform.Translate(new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y)));

            }
        }
    }



}