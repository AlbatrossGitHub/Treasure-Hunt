using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform; //variable followTransform of datatype Transform. Will drag object it need to follow in the parameter
    public BoxCollider2D worldBounds; //outer bounds of mapspace so Camera cant leave it. Will create big object with boxcollider2d and that will be the bounds

    //variables holding the positions of our bounds
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    //variables holding the positions of our camera
    float camX;
    float camY;

    float camRatio; //x
    float camSize; //y

    //reference to camera component
    Camera mainCam;

    //we have to add a little math for our smoothing / staggered effect of camera following the ball
    Vector3 smoothPos;

    //the speed at which we are smoothing and how quickly the camera catches up to the player when it moves.
    public float smoothRate;

    // Start is called before the first frame update
    void Start()
    {
        xMin = worldBounds.bounds.min.x; //xMin holds the worldbounds, .bounds is a reerence to the box collider component's bounds field/property, then the minimum side of the field
        xMax = worldBounds.bounds.max.x;
        yMin = worldBounds.bounds.min.y;
        yMax = worldBounds.bounds.max.y;

        mainCam = gameObject.GetComponent<Camera>();

        //finding the y of our camera
        camSize = mainCam.orthographicSize;
        camRatio = (xMax + camSize) / 8.0f; //fidning the x of our camera and doing a little math so that we are in the center
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() //by putting the follow code in FixedUPdate instead of in Update, the camera is less jumpy and more smooth.
    //Fixed Update has the framrate of the physics system, not every frame.
    {
        //clamping in math is when you limit a number to a certain area, where if it goes over it rounds down and goes under it rounds up
        camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + camRatio, xMax - camRatio);
    
        smoothPos = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY, gameObject.transform.position.z), smoothRate); //lerping is linear interpolation. Moving between 2 points at a certain rate. has 3 parameters- where u are, where ur going, and the rate
        gameObject.transform.position = smoothPos;
    }
}
