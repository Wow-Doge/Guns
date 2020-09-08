using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleSystem2 : MonoBehaviour
{

    public enum State
    {
        Idle,
        Active,
        End
    }
    private State state;

    [SerializeField]
    private Wave[] waveArray;
    public BattleTrigger battleTrigger;

    private void Awake()
    {
        state = State.Idle;
    }

    private void Start()
    {
        battleTrigger.OnPlayerEnterTrigger += StartTheBattle;
    }

    private void StartTheBattle(object sender, EventArgs e)
    {
        if (state == State.Idle)
        {
            StartBattle();
        }
    }

    void StartBattle()
    {
        Debug.Log("Start battle");
        state = State.Active;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Active:
                foreach (Wave wave in waveArray)
                {
                    if (GameObject.FindGameObjectWithTag("Enemy") == null)
                    {
                        wave.Update();
                    }
                }
                break;
        }
    }

    [System.Serializable]
    private class Wave
    {
        public GameObject[] enemies;
        public Transform spawnLocation;
        void SpawnEnemies()
        {
            foreach (GameObject enemy in enemies)
            {
                Instantiate(enemy, spawnLocation.position, Quaternion.identity);
            }
        }

        public void Update()
        {
            SpawnEnemies();
        }
    }
}
