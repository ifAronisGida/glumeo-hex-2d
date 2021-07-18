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


    public GridManager gridManager;

    public Hex baseHex;

    // Start is called before the first frame update
    void Start()
    {
        SetStartingHexAsParent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (!gridManager.isSelectionActive)
        {
            Debug.Log("select");
            gridManager.isSelectionActive = true;
            gridManager.ShowPossibleDestinations(baseHex, unit.speed);
            gridManager.selectedUnits = unit;
        }
    }

    public void UpdateBaseHex()
    {
        baseHex = GetComponentInParent<Hex>();
    }

    private void SetStartingHexAsParent()
    {
        foreach (Transform startPositionTransform in NetworkManager.startPositions)
        {
            Debug.Log(startPositionTransform.position);

            Hex startingHex = startPositionTransform.GetComponent<Hex>();
            Debug.Log(startingHex);

            //TODO: no collision
            if (boxCollider.bounds.Intersects(startingHex.polyCollider.bounds))
            {
                startingHex.HighlightSelf();

                //set parent
                unit.transform.SetParent(startingHex.transform);
                baseHex = startingHex;

                //set z coordinate for foreground interactivity
                var unitPos = unit.transform.position;
                unitPos.z -= 1;
                unit.transform.position = unitPos;
            }
        }
    }
}
