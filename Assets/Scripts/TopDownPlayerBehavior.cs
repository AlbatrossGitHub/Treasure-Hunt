using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerBehavior : MonoBehaviour
{

    //Rigidbody2D myRigidbody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //myRigidbody = gameObject.GetComponent<Rigidbody2D>();
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
}
