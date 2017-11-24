using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public bool Active = false;

    [Tooltip("Drag any type of Transform here. The camera will always look towards its center.")]
    public Transform LookAt; // where camera should look towards
    [Tooltip("Drag a Quad here. It will determine the area in which the camera can move.")]
    public Transform moveRange; // shows range in which camera may move
    Vector2 screenSize;

    [Range(0.02f, 0.06f)]
    public float strength;
    [Range(0.5f, 0.9f)]
    public float damping; 
    public bool LeftRightInverted;
    public bool UpDownInverted;

    Vector2 acc; // acceleration
    Vector2 vel; // velocity
    Vector2 posCurrent; // current position
    Vector2 posGoal; // goal for position in 2D on range [0,0,1,1]

	// Use this for initialization
	void Start () {
        screenSize = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        Screen.fullScreen = true;

        posGoal = new Vector2(0.5f, 0.5f);
        posCurrent = new Vector2(0.5f, 0.5f); // assume camera to start in the middle. 
        vel = new Vector2(0, 0); 
    }
	
	// Update is called once per frame
	void Update () {
        if (Active)
        {
            if (Input.GetMouseButton(0)) // if left mouse is clicked or MS Surface is touched, get position of mouse
            {
                if (LeftRightInverted) { posGoal.x = Input.mousePosition.x / screenSize.x; }
                else { posGoal.x = 1 - Input.mousePosition.x / screenSize.x; }

                if (UpDownInverted) { posGoal.y = 1 - Input.mousePosition.y / screenSize.y; }
                else { posGoal.y = Input.mousePosition.y / screenSize.y; }
            }
            else
            {
                posGoal = new Vector2(0.5f, 0.5f);
            }

            acc = strength * (posGoal - posCurrent) - vel * damping;
            vel = vel + acc;
            posCurrent = posCurrent + vel;

            transform.position = moveRange.TransformPoint(posCurrent.x - 0.5f, posCurrent.y - 0.5f, 0); // project to moveRange surface
            transform.LookAt(LookAt);
        }
    }

    public void SetActive() // to be used from main menu script
    {
        Active = true;
    }

}
