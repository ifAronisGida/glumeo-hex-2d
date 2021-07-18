using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{

    public List<GameObject> units;
    public GameObject gridManager;
    public GameObject soldier;

    public override void OnStartClient()
    {
        base.OnStartClient();
        gridManager = GameObject.Find("GridManager");
        GetStartingUnit();
    }

    public void GetStartingUnit()
    {
        //get starting pos
        Vector3 startUnitPos = this.transform.position;
        startUnitPos.z -= 1;

        //instantiate unit game object
        GameObject startUnit = Instantiate(soldier, startUnitPos, Quaternion.identity);
        Debug.Log(startUnit);

        //pass grid manager to the object
        InteractiveUnit interactiveStartUnit = startUnit.GetComponent<InteractiveUnit>();
        interactiveStartUnit.gridManager = gridManager.GetComponent<GridManager>();

        //add game object to player units
        units.Add(startUnit);
    }
}
