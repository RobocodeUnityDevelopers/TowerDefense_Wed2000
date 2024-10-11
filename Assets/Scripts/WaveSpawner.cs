using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] enemyAPrefs;
    [SerializeField] private Transform spawnPoint;
    [Header("������� ������� �� �������")]
    [SerializeField] private float countdown = 3f;
    [Header("������� ������� �� ������ ��'����")]
    [SerializeField] private float timeBetweenSpawnEnemy = 1f;
    private int waveNumber = 1;
    void Start()
    {
        StartCoroutine(SpawnWave());
    }
    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(countdown);

        for(int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyAPrefs[0], spawnPoint);
            yield return new WaitForSeconds(timeBetweenSpawnEnemy);
        }
        waveNumber++;
        StartCoroutine(SpawnWave());
    }
}
