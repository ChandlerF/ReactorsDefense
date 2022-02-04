using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> Spawners = new List<Transform>();
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float StartTimer;
    private float Timer, CachedTimer;
    private int Difficulty = 1;

    void Start()
    {
        Timer = StartTimer;
        CachedTimer = StartTimer;
    }

    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Spawn(Difficulty);
        }
    }


    private void Spawn(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            int x = Random.Range(0, Spawners.Count);
            Instantiate(Enemy, Spawners[x].position, Quaternion.identity);
        }

        if (NumberCounter.instance.Value >= 1200)
        {
            Difficulty = 3;
            StartTimer = CachedTimer + 3f;
        }
        else if (NumberCounter.instance.Value >= 800)
        {
            Difficulty = 2;
            StartTimer = CachedTimer + 1f;
        }
        else if(NumberCounter.instance.Value >= 600)
        {
            Difficulty = 2;
            StartTimer = CachedTimer + 2.5f;
        }

        Timer = StartTimer;
    }
}
