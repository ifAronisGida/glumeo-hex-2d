using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GridManager : NetworkBehaviour
{
    public Hex[] allHice;
    public Soldier selectedUnit;

    public bool isSelectionActive;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        allHice = GetComponentsInChildren<Hex>();
        isSelectionActive = false;
        Debug.Log("All hice count: " + allHice.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //gets neighboring hice
    public void ShowPossibleDestinations(Hex initialHex, int step)
    {
        //return if steps reached
        if (step == 0) return;

        Debug.Log("initial hex:" + initialHex + "step: " + step);
        Debug.Log("all hice: " + allHice.Length);

        foreach (Hex hex in allHice)
        {
            //if colliding with each other
            if (hex.polyCollider.bounds.Intersects(initialHex.polyCollider.bounds))
            {
                //call it again for extended 
                ShowPossibleDestinations(hex, step - 1);
                hex.isPossibleDestination = true;
                hex.HighlightSelf();
            }
        }
    }

    public void ResetMovement()
    {
        foreach (Hex hex in allHice)
        {
            hex.RevertHightligh();
            hex.isPossibleDestination = false;
        }
    }

}
