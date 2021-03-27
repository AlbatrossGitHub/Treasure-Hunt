using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PurpleButtonBehavior : MonoBehaviour
{

    Animator myAnim;
    public GameObject transition;
    Animator transitionAnimator;
    public TopDownPlayerBehavior playerScript;
    int roomNumber = SceneManager.GetActiveScene().buildIndex;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = gameObject.GetComponent<Animator>();
        transitionAnimator = transition.GetComponent<Animator>();
        GameObject.Find("Music").GetComponent<MusicManager>().PlaySwooshSound();
        transitionAnimator.SetInteger("Room Number", roomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            myAnim.SetBool("Finish", true);
            GameObject.Find("Music").GetComponent<MusicManager>().PlayButtonSound();
            
        }
    }

    void Transition()
    {
        transitionAnimator.SetBool("Finish", true);
        GameObject.Find("Music").GetComponent<MusicManager>().PlaySwooshSound();
    }
}
