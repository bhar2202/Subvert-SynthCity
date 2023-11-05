using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float rotSpeed = 90.0f;
    
    [SerializeField] private float threshold = 5.0f;
    
    [SerializeField] private float correctRot = 90.0f;
    
    
    
    [SerializeField] private Sprite lightSprite;
    [SerializeField] private Sprite darkSprite;

    private float[] rots = new[] { 0.0f, 90.0f, 180.0f, 270.0f };
    private float timeElapsed = 0;
    private bool isRotating = false;
    private float targetRotation = 0.0f;

    public float inPosition = false;

  
    
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
        //generate random rotation
        transform.rotation = Quaternion.Euler(0, 0, rots[Random.Range(0,4)]);
        if (isLit)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = lightSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isRotating)
        {
            float rotationAmt = rotSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationAmt);
            if (Mathf.Abs(transform.rotation.eulerAngles.z - targetRotation) < threshold)
           {
               // Snap to the exact 90-degree rotation
               transform.rotation = Quaternion.Euler(0, 0, targetRotation);
               isRotating = false;
           }
        }
        
        
        if ( !isRotating && Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Raycast sent");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject){

                isRotating = true;
                targetRotation += 90.0f;
                if (targetRotation >= 360.0f)
                {
                    targetRotation = 0.0f;
                }
            }
        }


    }


}
