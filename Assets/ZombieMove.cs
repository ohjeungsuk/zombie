using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public float Zspeed;
    public AudioClip[] zsound;

    private Vector3 player;
    private Animator ani;
    private AudioSource _audioSource;

    void Start()
    {
        ani = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        player = new Vector3(0, 0, -5);
        Zspeed = 1.5f;

        _audioSource.PlayOneShot(zsound[Random.Range(0,2)]);

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player , Zspeed * Time.deltaTime);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(zsound[2]);
            ani.SetTrigger("Attack");
            Zspeed = 0;
        }
    }



}
