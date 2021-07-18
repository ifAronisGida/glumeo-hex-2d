using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractiveHex : MonoBehaviour
{

    private GridManager gridManager;
    private Hex hex;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GetComponentInParent<GridManager>();
        hex = GetComponent<Hex>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseEnter()
    {
        if (!gridManager.isSelectionActive)
        {
            hex.HighlightSelf();
        }

        //if (gridManager.isSelectionActive && hex.isPossibleDestination)
        //{

        //    var hexPosition = hex.transform.position;
        //    hexPosition.z += 1;
        //    gridManager.SelectedUnit.transform.position = hexPosition;

        //    gridManager.SelectedUnit.transform.SetParent(hex.transform);
        //    gridManager.SelectedUnit.interactiveUnit.UpdateBaseHex();
        //}

    }

    public void OnMouseExit()
    {
        if (!gridManager.isSelectionActive)
        {
            hex.RevertHightligh();
        }
    }

    //public void OnMouseDown()
    //{
    //    if (gridManager.IsSelectionActive && hex.IsPossibleDestination)
    //    {
    //        var hexPosition = hex.transform.position;
    //        hexPosition.z -= 1;
    //        gridManager.SelectedUnit.transform.position = hexPosition;
    //        gridManager.IsSelectionActive = false;
    //        gridManager.ResetMovement();
    //    }
    //}
}
