using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circuitManager : MonoBehaviour
{
    private int numCells = 0;
    
    private int correctCells = 0;
    private GameObject[] cells;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cells = GameObject.FindGameObjectsWithTag("Cell");
        numCells = cells.Length;
        Debug.Log("num cells: " + numCells);
    }

    public void incrCorrCells()
    {
        correctCells++;
        Debug.Log(correctCells);
        if (correctCells == numCells)
        {
            foreach (GameObject item in cells)
            {
                item.GetComponent<SpriteRenderer>().sprite = item.GetComponent<CellController>().lightSprite;
            }
        }
    }
    
    public void decrCorrCells()
    {
        correctCells--;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
