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

    // Start is called before the first frame update
    void Start()
    {
        endTime = endTimeReset;
        numScenes -= 1;
        //myRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(Input.GetKeyDown(KeyCode.N)){
            NextScene();
        }
        if(countDown == true){
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
        }
    }

    void FixedUpdate()
    {
        //Physics2D.gravity = Vector2.zero;
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.up*Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left*Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.down*Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right*Time.deltaTime*speed);
        }
    }

    void NextScene()
    {
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextIndex > numScenes){
                nextIndex = 0;
            }
        SceneManager.LoadScene(nextIndex);
    }
}
