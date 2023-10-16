using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
    // Start is called before the first frame update

    // i would like to designate current and target object, but ill get to that when i have more time
    public GameObject toaster_obj;
    public GameObject roomba_obj;


    // i hate this and ill get rid of it when current and target are dynamic
    public bool toaster_active = true;

    void Start()
    {
        toaster_obj = GameObject.Find("Toaster");
        roomba_obj = GameObject.Find("Roomba");
        toaster_obj.GetComponent<RobotBehavior>().possess_him();
    }

    // Update is called once per frame
    void Update()
    {
        var distance = (toaster_obj.transform.position - roomba_obj.transform.position).magnitude;
        if (Input.GetKeyDown("p") && distance < 4)
        {
            if (toaster_active)
            {
                toaster_obj.GetComponent<RobotBehavior>().enabled = false;
                toaster_obj.GetComponent<RobotBehavior>().possess_him();
                roomba_obj.GetComponent<RobotBehavior>().enabled = true;
                roomba_obj.GetComponent<RobotBehavior>().possess_him();


                toaster_active = false;
            }
            else
            {
                toaster_obj.GetComponent<RobotBehavior>().enabled = true;
                roomba_obj.GetComponent<RobotBehavior>().enabled = false;
                roomba_obj.GetComponent<RobotBehavior>().possess_him();
                toaster_obj.GetComponent<RobotBehavior>().possess_him();
                toaster_active = true;
            }
        }
    }
}
