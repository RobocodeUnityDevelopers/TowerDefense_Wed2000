using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetting : MonoBehaviour
{
    [SerializeField] private uint health;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration; // змінна
    [SerializeField] private AudioClip deathClip;
    private AudioSource src;
    public uint Health { get { return health; }} // властивість // property


    private void Awake()
    {
        src = GetComponent<AudioSource>();
        src.clip = deathClip;
     
    }
    public float GetSpeed()
    {
        return speed;
    }

    public float GetAcceleration()
    {
        return acceleration;
    }

    public void SetSlowDown()
    {
        StartCoroutine(SlowDown());
    }

    private IEnumerator SlowDown()
    {
        speed = speed / 2; //speed /=2;
        yield return new WaitForSeconds(.5f);
        speed = speed * 2; // speed *=2;
    }

    public void Damage(uint damageVal)
    {
        if (health < damageVal)
        {
            StartCoroutine(DestroyAfterSound());
            CoinController.AddCoin(Random.Range(10,30));
            
        }
        health -= damageVal;
    }

    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        while (src.isPlaying)src.Play();
        print("debug");
    }
}
