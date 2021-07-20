using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Soldier : NetworkBehaviour
{
    public int health;
    public int speed;
    public InteractiveUnit interactiveUnit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cmdSyncSoldierPosition(transform.position);
    }
    
    [Command]
    private void cmdSyncSoldierPosition(Vector3 currentPos)
    {
        ServerSyncSoldierPos(currentPos);
    }

    [ClientRpc]
    private void ServerSyncSoldierPos(Vector3 currentPos)
    {
        if(!isLocalPlayer)
        {
            transform.position = currentPos;
        }
    }

}
