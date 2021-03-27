using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    SpriteRenderer myRenderer; //makes variable myRenderer of datatype SpriteRenderer
    Animator myAnim;


    //SpriteRenderer gateRenderer;

    //public Color floorColor; //makes variable floorcolor of datatype Color
    //public Color pushedColor; //makes variable gatecolor of datatype color
    //public Color originalColor;
    public string boxType;
    public GameObject door;
    public bool toggleButton = false; //most of them will be the box button
    bool pushable = true;
    private Color startColor;
    private Color pushedColor;
    private float opacity = .2f;
    private SpriteRenderer doorRenderer = null;
    private SpriteRenderer doorRenderer2 = null;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>(); //sets myRenderer to the correct SpriteRenderer
        //myBody = gameObject.GetComponent<Rigidbody2D>(); //sets myBody to the correct Rigidbody2d
        //gateRenderer = gameObject.GetComponent
        //myRenderer.color = originalColor;
        myAnim = gameObject.GetComponent<Animator>();
        if(boxType == "Red Box"){
            myAnim.SetBool("Red", true);
        }
        if(toggleButton == true){
            myAnim.SetBool("Toggle Button", true);
        } else {
            myAnim.SetBool("Toggle Button", false);
        }
        if(door.GetComponent<SpriteRenderer>() != null){
            //Debug.Log("Not Pair");
            doorRenderer = door.GetComponent<SpriteRenderer>();
        } else {
            Debug.Log(door.transform.GetChild(0).gameObject.name);
            doorRenderer = door.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            doorRenderer2 = door.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        }
        startColor = doorRenderer.color;
        pushedColor = new Color(startColor.r-.4f, startColor.g-.4f, startColor.b-.4f, opacity);

    }


    void Update()
    {
        if(toggleButton == false){
            pushable = true; //if its a button that needs to stay pushed, then we set pushable to be true, meaning that nothing is hitting this button
        }
    }

    void OnTriggerStay2D(Collider2D other) //is something still on the button?
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == boxType){ 
            if(boxType == "Red Box"){
                myAnim.SetBool("Red Down", true);
            } else {
                myAnim.SetBool("Blue Down", true);
            }
            //myRenderer.color = pushedColor;
            //Destroy(door);
            //door.SetActive(false);
            pushable = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == boxType){ //when it passes the gate it changes color
            if(pushable == true){
                //myRenderer.color = originalColor;
                //Destroy(door);
                //door.SetActive(true);
            if(boxType == "Red Box"){
                myAnim.SetBool("Red Down", false);
            } else {
                myAnim.SetBool("Blue Down", false);
            }
            }
        }
    }

    public void OpenDoor(){
        //door.SetActive(false);
        doorRenderer.color = pushedColor;
        doorRenderer.gameObject.GetComponent<BoxCollider2D>().enabled=false;
        if(doorRenderer2 != null){
            doorRenderer2.color = pushedColor;
            doorRenderer2.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            
        }
        GameObject.Find("Music").GetComponent<MusicManager>().PlayButtonSound();
    }

    public void CloseDoor(){
        //door.SetActive(true);
        doorRenderer.color = startColor;
        doorRenderer.gameObject.GetComponent<BoxCollider2D>().enabled=true;
        if(doorRenderer2 != null){
            doorRenderer2.color = startColor;
             doorRenderer2.gameObject.GetComponent<BoxCollider2D>().enabled=true;
        
        }
        GameObject.Find("Music").GetComponent<MusicManager>().PlayButtonSound();
    }
}