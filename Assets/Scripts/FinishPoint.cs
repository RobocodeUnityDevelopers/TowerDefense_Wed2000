using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private GameObject touchFX;
    private HPController controller;
    
    private void Start()
    {
        controller = FindObjectOfType<HPController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(touchFX, transform.position, Quaternion.identity);
            controller.Health--;
        }
    }
}
