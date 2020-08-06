using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{

    private bool isDragging;
    private float reachable;
    GameObject player;
    GameObject grid;
    GameObject gridRed;
    Collider2D collider;

    public bool canOnPlayer = false;

    SpriteRenderer spriteRenderer;
    void Start(){
        collider = GetComponent<Collider2D>(); 
        player = GameObject.Find("Adult");
        grid = player.GetComponent<BetterPlayerMovement>().grid;
        gridRed = player.GetComponent<BetterPlayerMovement>().gridRed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    public void OnMouseDown()
    {
        isDragging = true;

            spriteRenderer.color = new Color(15f, 15f, 15f, 15f);
    }

    public void OnMouseUp()
    {
        isDragging = false;
        collider.enabled = true;
        spriteRenderer.color = new Color(255f, 255f, 255f, 255f);

        if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 0.7 && !canOnPlayer){

            
            gameObject.transform.position = gameObject.transform.position + new Vector3(0,1,0);



        }

            grid.SetActive(false);
            gridRed.SetActive(false);
    }

    void Update()
    {

            Vector2 mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (isDragging) {
            collider.enabled = false;
            //reachable = true;
            
            reachable = Vector3.Distance(gameObject.transform.position, player.transform.position);
            //Debug.Log(reachable);
            if(reachable < 4){
                grid.SetActive(true);
            transform.Translate(new Vector2(Mathf.Round(mousePosition.x), Mathf.Round(mousePosition.y)));

            }else{
                gridRed.SetActive(true);
            }
        }else{
            
        }
    }



}