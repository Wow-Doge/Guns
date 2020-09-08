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
        Vector3 spawnposition;
        public Transform transform;
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
                spawnposition.x = UnityEngine.Random.Range(transform.position.x - 5, transform.position.x + 5);
                spawnposition.y = UnityEngine.Random.Range(transform.position.y - 2, transform.position.y + 2);
                spawnposition = new Vector3(spawnposition.x, spawnposition.y, transform.position.z);
                Instantiate(enemy, spawnposition, Quaternion.identity);
            }
        }

        public bool WaveOver()
        {
            if (timer < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
