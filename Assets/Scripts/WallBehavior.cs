using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{

    public float sightDist;

    //public Vector3 targetMod;

    public Transform target;

    public BoxCollider2D col;

    public float numOfRays;

    public float raySeparation;

    // Start is called before the first frame update
    void Start()
    {
        //col = gameObject.GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        bool hitAnything = false;

        //target = transform.position + targetMod;

        //Vector3 rayOffset = new Vector3(0, (transform.localScale.y /2) + .1f, 0);

            for (float i = 0; i < numOfRays; i+=raySeparation){
                
                //LEFT
                Vector3 offPos= new Vector3(transform.position.x - i, transform.position.y, transform.position.z);
                RaycastHit2D hit = Physics2D.Raycast(offPos, target.localPosition, sightDist);
                Debug.DrawRay(offPos, target. localPosition, Color.blue);
                if(hit.collider != null){
                    if(hit.collider.gameObject.tag != "Wall"){
                        col.enabled = true;
                        hitAnything = true;
                        Debug.Log(hit.collider.name);
                    }
                }
                else {
                    if(hitAnything == false){
                        col.enabled = false;
                    }
                }

                //RIGHT
                Vector3 offPosR= new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
                RaycastHit2D hitR = Physics2D.Raycast(offPosR, target.localPosition, sightDist);
                Debug.DrawRay(offPosR, target. localPosition, Color.blue);
                if(hitR.collider != null){
                    if(hitR.collider.gameObject.tag != "Wall"){
                        col.enabled = true;
                        hitAnything = true;
                        Debug.Log(hitR.collider.name);
                    }
                }
                else {
                    if(hitAnything == false){
                        col.enabled = false;
                    }
                }
        }
    }
}
