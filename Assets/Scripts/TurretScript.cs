using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Header("Налаштування кулі")]
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Transform[] barrels;
    [SerializeField] private float countdown;
    private bool canShoot = true;


    [SerializeField] private float range = 0f;
    private Transform target;
    [SerializeField] private float turnSpeed = 10f;

    private int barrelIndex = 0;
    [Header("Effects")]
    [SerializeField] private GameObject hitFX;
    [SerializeField] private AudioClip hitClip;
    private AudioSource src;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
        src.clip = hitClip;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    // Update is called once per frame
    private void Update()
    {
        if(target != null)
        {
            Look();
            if (canShoot)
            {
                StartCoroutine(Shoot(barrelIndex));
                barrelIndex++;
                if (barrelIndex >= barrels.Length) barrelIndex = 0;
                canShoot = !canShoot;
            }
        }
    }

    private void Look()
    {
        Quaternion lookAt = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAt, Time.deltaTime * turnSpeed);
    }

    private void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject currentTarget = null;
        float distance = Mathf.Infinity;

        foreach(GameObject target in targets)
        {
            float distaneToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if(distaneToEnemy < distance)
            {
                distance = distaneToEnemy;
                currentTarget = target;
            }
        }
        if (distance <= range && currentTarget != null)
        {
            target = currentTarget.transform;
        }
        else
        {
        target = null;
        }
    }

    private IEnumerator Shoot(int numBarrel)
    {
        src.pitch = Random.Range(0.9f, 1.1f);
        src.Play();
        GameObject bullet = Instantiate(bulletPref, barrels[numBarrel]);
        bullet.transform.SetParent(null);
        bullet.GetComponent<BulletScript>().TakeForce(target);

        Instantiate(hitFX, barrels[barrelIndex].position, Quaternion.identity);

        yield return new WaitForSeconds(countdown);
        canShoot = !canShoot;
    }
}
