using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float rotSpeed = 90.0f;
    
    [SerializeField] private float threshold = 5.0f;
    
    [SerializeField] private float correctRot = 90.0f;

    [SerializeField] private GameObject PuzzleManager;
    
    [SerializeField] public Sprite lightSprite;
    [SerializeField] public Sprite darkSprite;
    
    [SerializeField] public bool isICell;
    [SerializeField] public bool isXCell;

    private float[] rots = new[] { 0.0f, 90.0f, 180.0f, -90.0f };
    private float timeElapsed = 0;
    // private bool isRotating = false;

    private float targetRotation = 0.0f;

    public bool inPosition = false;

  
    
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     Debug.Log("Trigger Collision");
    //     if (other.GetComponent<CellController>().isLit)
    //     {
    //         isLit = true;
    //         gameObject.GetComponent<SpriteRenderer>().sprite = lightSprite;
    //     }
    // }
    
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (isRotating)
    //     {
    //         isLit = false;
    //                 gameObject.GetComponent<SpriteRenderer>().sprite = darkSprite;
    //     }
    //     
    // }
    
    void Start()
    {

        correctRot = gameObject.transform.eulerAngles.z;
        
        //generate random rotation
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rots[Random.Range(0, 4)]);
        // if (isLit)
        // {
        //     gameObject.GetComponent<SpriteRenderer>().sprite = lightSprite;
        // }

        if (isXCell || Mathf.Abs(gameObject.transform.eulerAngles.z - correctRot) < threshold)
        {
            inPosition = true;
            PuzzleManager.GetComponent<circuitManager>().incrCorrCells();
        }
        else if (isICell && Mathf.Abs(gameObject.transform.eulerAngles.z - correctRot + 180.0f) < threshold)
        {
            inPosition = true;
            PuzzleManager.GetComponent<circuitManager>().incrCorrCells();
             //Debug.Log(inPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // if (isRotating)
        // {
        //     float rotationAmt = rotSpeed * Time.deltaTime;
        //     transform.Rotate(Vector3.forward, rotationAmt);
        //     if (Mathf.Abs(transform.rotation.eulerAngles.z - targetRotation) < threshold)
        //    {
        //        // Snap to the exact 90-degree rotation
        //        transform.rotation = Quaternion.Euler(0, 0, targetRotation);
        //        isRotating = false;
        //    }
        // }
        
        
        // if ( !isRotating && Input.GetMouseButtonDown(0))
        if (!isXCell && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Raycast sent");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                //Debug.Log("Raycast hit: " + (gameObject.transform.rotation.z));
                //gameObject.transform.rotation = Quaternion.Euler(0,0, gameObject.transform.rotation.z + 90f);

                transform.Rotate(Vector3.forward * 90f);

                //check if rotation is at target rotation
                if (Mathf.Abs(gameObject.transform.eulerAngles.z - correctRot) < threshold)
                {
                    inPosition = true;
                    PuzzleManager.GetComponent<circuitManager>().incrCorrCells();
                    //Debug.Log(inPosition);
                }
                else if (isICell && Mathf.Abs(gameObject.transform.eulerAngles.z - correctRot + 180.0f) < threshold)
                {
                    inPosition = true;
                    PuzzleManager.GetComponent<circuitManager>().incrCorrCells();
                }
                else if (inPosition)
                {
                    inPosition = false;
                    PuzzleManager.GetComponent<circuitManager>().decrCorrCells();
                }
                
                // isRotating = true;
                // targetRotation += 90.0f;
                // if (targetRotation >= 360.0f)
                // {
                //     targetRotation = 0.0f;
                // }
            }
        }


    }


}
