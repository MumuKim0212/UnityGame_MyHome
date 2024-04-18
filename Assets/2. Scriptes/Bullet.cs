using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody rb;

    public GameObject effect;

    public AudioClip dieSound;
    public AudioSource audios;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;
        Destroy(gameObject, 5.4f);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.collider.tag == "Player")
        {
            PlayerController playerController = target.collider.GetComponent<PlayerController>();

            if(playerController != null )
            {
                audios.PlayOneShot(dieSound);
                Instantiate(effect, transform.position, Quaternion.identity);
                playerController.Die();
            }
        }
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
