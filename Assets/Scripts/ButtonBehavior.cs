using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    SpriteRenderer myRenderer; //makes variable myRenderer of datatype SpriteRenderer

    //SpriteRenderer gateRenderer;

    //public Color floorColor; //makes variable floorcolor of datatype Color
    public Color pushedColor; //makes variable gatecolor of datatype color
    public Color originalColor;
    public string boxType;
    public GameObject door;
    public bool toggleButton = false; //most of them will be the box button
    bool pushable = true;


    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>(); //sets myRenderer to the correct SpriteRenderer
        //myBody = gameObject.GetComponent<Rigidbody2D>(); //sets myBody to the correct Rigidbody2d
        //gateRenderer = gameObject.GetComponent
        myRenderer.color = originalColor;
    }

    void Update()
    {
        if(toggleButton == false){
            pushable = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == boxType){ //when it passes the gate it changes color
            myRenderer.color = pushedColor;
            //Destroy(door);
            door.SetActive(false);
            pushable = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == boxType){ //when it passes the gate it changes color
            if(pushable == true){
                myRenderer.color = originalColor;
                //Destroy(door);
                door.SetActive(true);
            }
        }
    }
}