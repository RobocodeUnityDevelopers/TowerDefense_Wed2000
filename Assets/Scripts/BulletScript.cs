using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private uint damage;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void TakeForce(Transform target)
    {
        Vector3 dir = target.position - transform.position;
        rb.AddForce(dir * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemySetting>().Damage(damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
