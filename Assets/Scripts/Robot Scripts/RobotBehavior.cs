using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobotBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Robot robotType;
    
    public Rigidbody2D rigidb;

    void Awake()
    {
        robotType = GetComponent<Robot>();
        rigidb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //standard player movement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * 2;

        if (Input.GetKeyDown("space"))
        {
            robotType.Action();
        }
        if (Input.GetKeyDown("r"))
        {
            robotType.Possessed();
        }

    }
    public void possess_him()
    {
        robotType.Possessed();
    }

}
