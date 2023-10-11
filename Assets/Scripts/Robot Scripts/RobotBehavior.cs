using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobotBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Robot robotType;
    void Start()
    {
        robotType = GetComponent<Robot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            robotType.Action();
        }
        if (Input.GetKeyDown("r"))
        {
            robotType.Possessed();
        }
    }

}
