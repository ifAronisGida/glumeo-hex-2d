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

        if (gridManager.isSelectionActive && hex.isPossibleDestination)
        {

            var hexPosition = hex.transform.position;
            hexPosition.z += 1;
            gridManager.selectedUnit.transform.position = hexPosition;
            gridManager.selectedUnit.GetComponent<InteractiveUnit>().SetUnitPosition(false);

        }

    }

    public void OnMouseExit()
    {
        if (!gridManager.isSelectionActive)
        {
            hex.RevertHightligh();
        }
    }

    public void OnMouseDown()
    {
        if (gridManager.isSelectionActive && hex.isPossibleDestination)
        {

            var hexPosition = hex.transform.position;
            hexPosition.z -= 2;
            gridManager.selectedUnit.GetComponent<InteractiveUnit>().SetUnitPosition(false);
            gridManager.selectedUnit.transform.position = hexPosition;
            gridManager.isSelectionActive = false;
            gridManager.ResetMovement();
        }
    }
}
