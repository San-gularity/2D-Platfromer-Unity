using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;    //Array of all the background to be parallaxed
    private float[] parallaxScales;     //automates how uch to parallax each background
    public float smoothing = 1f;

    private Transform cam;          //reference to the main camera transform
    private Vector3 previouscampos;    //previous position of camera.(frame)

    void Awake()
    {
        //set up the reference(cam)
        cam = Camera.main.transform;
    }

    void Start()
    {
        //the previous frame is stored
        previouscampos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for(int i =0; i <backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //for each backgrpound
        for(int i=0; i< backgrounds.Length; i++)
        {
            //parallax is the opposite of the camera movement as the previous frame multi by the scale
            float parallaxX = (previouscampos.x - cam.position.x) * parallaxScales[i];
            //float parallaxY = (previouscampos.y - cam.position.y) * parallaxScales[i];

            //set target x position is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallaxX;
            //float backgroundTargetPosY = backgrounds[i].position.x + parallaxY;

            // create a target position which is thw backgroind current position with target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // fade between current and target smoothly using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }
        //set the previouscampos to the camera position now
        previouscampos = cam.position;
    }
}
