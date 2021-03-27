using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    private AudioSource buttonSource;
    private AudioSource swooshSource;

    //Like start but called even before start. Called when the game is loading, before anything even gets rendered
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonSource = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        swooshSource = transform.GetChild(1).gameObject.GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        //if(!buttonSource.isPlaying){
            buttonSource.Play();
        //}
    }

    public void PlaySwooshSound()
    {
        swooshSource.Play();
    }

}
