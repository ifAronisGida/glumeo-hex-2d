using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class InteractiveUnit : NetworkBehaviour
{

    [SerializeField]
    private Soldier unit;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D boxCollider;

    public GameObject gridManagerObject;
    public GridManager gridManager;

    public Hex baseHex;

    // Start is called before the first frame update
    void Start()
    {
        gridManagerObject = GameObject.Find("GridManager");
        gridManager = gridManagerObject.GetComponent<GridManager>();
        SetUnitPosition(true);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log(gridManager.isSelectionActive);

        if (!gridManager.isSelectionActive)
        {
            Debug.Log("select");
            gridManager.isSelectionActive = true;
            Debug.Log(baseHex);
            gridManager.ShowPossibleDestinations(baseHex, unit.speed);
            gridManager.selectedUnit = unit;
        }
    }


    public void SetUnitPosition(bool isSpawning)
    {
        foreach (Hex hex in gridManager.allHice)
        {


            Hex startingHex = hex.transform.GetComponent<Hex>();

            Bounds soldierPos = boxCollider.bounds;
            Vector3 soldierPosVector = soldierPos.center;

            soldierPosVector.z = 0;
            soldierPos.center = soldierPosVector;

            Bounds hexPos = startingHex.polyCollider.bounds;
            Vector3 hexPosVector = hexPos.center;

            hexPosVector.z = 0;
            hexPos.center = hexPosVector;


            if (soldierPos.Intersects(hexPos))
            {
                //set parent
                //unit.transform.SetParent(startingHex.transform);
                baseHex = startingHex;

                //set z coordinate for foreground interactivity
                if (isSpawning)
                {
                    var unitPos = unit.transform.position;
                    unitPos.z = 0;
                    unitPos.z -= 1;
                    unit.transform.position = unitPos;
                }
            }
        }
    }
}
