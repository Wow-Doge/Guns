using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public BattleTrigger battleTrigger;
    public GameObject block;
    public BattleSystem battleSystem;


    private void Start()
    {
        block.SetActive(false);
        battleTrigger.OnPlayerEnterTrigger += LockDoor;
        battleSystem.OnWaveEnd += UnlockDoor;
    }

    private void UnlockDoor(object sender, System.EventArgs e)
    {
        block.SetActive(false);
        battleTrigger.OnPlayerEnterTrigger -= UnlockDoor;
    }

    private void LockDoor(object sender, System.EventArgs e)
    {
        block.SetActive(true); 
        battleTrigger.OnPlayerEnterTrigger -= LockDoor;
    }
}
