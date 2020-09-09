using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SocialPlatforms;
using System.Linq;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waveArray;
    public BattleTrigger battleTrigger;
    public event EventHandler OnWaveEnd;
    private enum State
    {
        Idle,
        Active,
        End,
    }
    private State state;
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
        switch(state)
        {
            case State.Active:
                foreach (Wave wave in waveArray)
                {
                    wave.Update();
                }
                TestBattleOver();
                break;
        }
    }

    private void TestBattleOver()
    {
        if (state == State.Active)
        {
            if (IsBattleOver())
            {
                state = State.End;
                Debug.Log("Battle end");
                OnWaveEnd?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private bool IsBattleOver()
    {
        foreach (Wave wave in waveArray)
        {
            if (wave.WaveOver())
            {
                
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    [System.Serializable]
    private class Wave
    {
        public float timer;
        public GameObject[] enemies;
        public Transform[] spawnLocations;
        public void Update()
        {
            if (timer >= 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    SpawnEnemies();
                }
            }
        }
        public void SpawnEnemies()
        {
            foreach (GameObject enemy in enemies)
            {
                Transform spawnLocation = spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)];
                Instantiate(enemy, spawnLocation.position, Quaternion.identity);
            }
        }

        public bool WaveOver()
        {
            if (timer < 0)
            {
                if (GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
