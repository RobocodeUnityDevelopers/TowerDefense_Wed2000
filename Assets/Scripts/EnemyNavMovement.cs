using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMovement : MonoBehaviour
{
    private Vector3 finishPoint;
    private NavMeshAgent navMesh;
    private EnemySetting setting;
    private void Start()
    {
        setting = GetComponent<EnemySetting>();
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        finishPoint = GameObject.FindGameObjectWithTag("Finish").gameObject.transform.position;

        navMesh.speed = setting.GetSpeed();
        navMesh.destination = finishPoint;

    }

    private void Update()
    {
        navMesh.speed = setting.GetSpeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Slow"))
        {
            setting.SetSlowDown();
        }
    }
}
