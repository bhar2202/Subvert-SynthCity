using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] robots;
    private GameObject current_obj;
    private GameObject target_obj;

    void Start()
    {
        current_obj = robots[0];
        current_obj.GetComponent<RobotBehavior>().possess_him();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("p"))
        {
            for (int i = 0; i < robots.Length; i++)
            {
                if (robots[i].name != current_obj.name)
                {
                    target_obj = robots[i];
                    var distance = (current_obj.transform.position - target_obj.transform.position).magnitude;
                    if (distance < 4)
                    {
                        current_obj.GetComponent<RobotBehavior>().enabled = false;
                        current_obj.GetComponent<RobotBehavior>().possess_him();
                        target_obj.GetComponent<RobotBehavior>().enabled = true;
                        target_obj.GetComponent<RobotBehavior>().possess_him();
                        current_obj = target_obj;
                        break;
                    }
                }
            }
        }
    }
}
