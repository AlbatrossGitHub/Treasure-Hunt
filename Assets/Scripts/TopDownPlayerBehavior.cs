using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopDownPlayerBehavior : MonoBehaviour
{

    //Rigidbody2D myRigidbody;
    public float speed;

    public int numScenes;

    public float endTimeReset;

    float endTime;

    bool countDown = false;

    private SpriteRenderer myRenderer;

    private Animator myAnim;

    private SpriteRenderer shadowRenderer; 

    public GameObject transition;

    Animator transitionAnimator;

    // Start is called before the first frame update
    void Start()
    {
        shadowRenderer = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        myAnim = gameObject.GetComponent<Animator>();
        endTime = endTimeReset;
        numScenes -= 1;
        transitionAnimator = transition.GetComponent<Animator>();
        //myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentLevel);
        transitionAnimator.SetInteger("Level Number", currentLevel-1);
        if(currentLevel < 2 || currentLevel == numScenes){
            if(Input.anyKeyDown){
                NextScene();
            }
        }
        if(countDown == false){
            Debug.Log("False!");
        }
        if(countDown == true){
            Debug.Log("True!");
            endTime -= Time.deltaTime;
            if(endTime <= 0){
                NextScene();
               endTime = endTimeReset;
                countDown = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Finish"){
            countDown = true;
            //NextScene();
            Debug.Log("Finish!");
        }
    }

    void FixedUpdate()
    {
        myAnim.SetBool("Moving", false);
        //moving false and then moving true in all the other ones
        Vector3 translateTarget = new Vector3(0, 0, 0);
        //Physics2D.gravity = Vector2.zero;
        if(Input.GetKey(KeyCode.W)){
            translateTarget += Vector3.up;
            myAnim.SetBool("Moving", true);
            //transform.Translate(Vector3.up*Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.A)){
            translateTarget += Vector3.left;
            myRenderer.flipX = true;
            shadowRenderer.flipX = true;
            myAnim.SetBool("Moving", true);
            //transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.S)){
            translateTarget += Vector3.down;
            myAnim.SetBool("Moving", true);
            //transform.Translate(Vector3.down*Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.D)){
            translateTarget += Vector3.right;
            myRenderer.flipX = false;
            shadowRenderer.flipX = false;
            myAnim.SetBool("Moving", true);
            //transform.Translate(Vector3.right*Time.deltaTime*speed);
        }
        transform.Translate(translateTarget*Time.deltaTime*speed);
    }

    public void NextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextIndex > numScenes){
                nextIndex = 0;
                Destroy(GameObject.Find("Music"));
            }
        SceneManager.LoadScene(nextIndex);
    }
}
