using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    GameObject bulletPrefab;
    Transform bulletTransform;
    public float rateMin = 0.5f;
    public float rateMax = 3f;
    public GameObject[] bulletList = new GameObject[8];

    Transform target;
    float spawnRate;
    float timeAfterSpawn;

    [System.Obsolete]
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(rateMin,rateMax);
        target = FindObjectOfType<PlayerController>().transform;
        bulletTransform = GetComponent<Transform>();

        // Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            bulletPrefab = bulletList[Random.Range(0,bulletList.Length)];
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(bulletTransform.transform.position);

            spawnRate = Random.Range(rateMin, rateMax);
        }
    }
}
