using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BattleDoor : MonoBehaviour
{
    public BattleTrigger battleTrigger;
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider2D;
    public BattleSystem battleSystem;


    private void Start()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
        tilemapRenderer.enabled = false;
        tilemapCollider2D.enabled = false;
        battleTrigger.OnPlayerEnterTrigger += LockDoor;
        battleSystem.OnWaveEnd += UnlockDoor;
    }
    
    private void UnlockDoor(object sender, System.EventArgs e)
    {
        tilemapRenderer.enabled = false;
        tilemapCollider2D.enabled = false;
        battleTrigger.OnPlayerEnterTrigger -= UnlockDoor;
    }

    private void LockDoor(object sender, System.EventArgs e)
    {
        tilemapRenderer.enabled = true;
        tilemapCollider2D.enabled = true;
        battleTrigger.OnPlayerEnterTrigger -= LockDoor;
    }
}
