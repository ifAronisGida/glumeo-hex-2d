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
        Debug.Log("called OnStartClient");
        base.OnStartClient();
        gridManager = GameObject.Find("GridManager");

    }

    public override void OnStartAuthority()
    {
        Debug.Log("called OnStartAuthority");
        base.OnStartAuthority();
        CmdGetStartingUnit();
    }

    [Server]
    private void SpawnUnit(GameObject unit, NetworkConnection connection)
    {
        NetworkServer.Spawn(unit,connection);
    }

    [Command]
    public void CmdGetStartingUnit()
    {
        //get starting pos
        Vector3 startUnitPos = transform.position;
        startUnitPos.z -= 1;

        //instantiate unit game object
        GameObject startUnit = Instantiate(soldier, startUnitPos, Quaternion.identity);
        Debug.Log("start unit instantiated: "+ startUnit != null);

        //pass grid manager to the object
        InteractiveUnit interactiveStartUnit = startUnit.GetComponent<InteractiveUnit>();
        interactiveStartUnit.gridManager = gridManager.GetComponent<GridManager>();
        Debug.Log("passed gridmanager to startingunit: " + interactiveStartUnit.gridManager != null);

        //add game object to player units
        units.Add(startUnit);
        Debug.Log("player units count: " + units.Count);

        //spawn in on the server
        SpawnUnit(startUnit, connectionToClient);
    }
}
