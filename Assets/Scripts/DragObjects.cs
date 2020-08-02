using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{

    private bool isDragging;
    private bool reachable;
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
        if (isDragging ) {
            //reachable = true;
            if(reachable){
            transform.Translate(new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y)));

            }
        }
    }

        void OnTriggerEnter2D(Collider2D col)
    {
     if(col.gameObject.tag == "Reach"){
         reachable = true;

     }
       
     
    }


        void OnTriggerExit2D(Collider2D col)
    {

     if(col.gameObject.tag == "Reach"){
     reachable = false;
     }
    }


}