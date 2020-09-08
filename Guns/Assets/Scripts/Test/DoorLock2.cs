using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock2 : MonoBehaviour
{
    public BattleTrigger battleTrigger;
    public GameObject block;
    public BattleSystem2 battleSystem2;


    private void Start()
    {
        battleTrigger.OnPlayerEnterTrigger += LockDoor;
        //battleSystem.OnWaveEnd += UnlockDoor;
    }

    private void UnlockDoor(object sender, System.EventArgs e)
    {
        block.transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
        battleTrigger.OnPlayerEnterTrigger -= UnlockDoor;
    }

    private void LockDoor(object sender, System.EventArgs e)
    {
        block.transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        battleTrigger.OnPlayerEnterTrigger -= LockDoor;
    }
}
