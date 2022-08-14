using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;

    //Drone'un s�rekli karakterimize bakmas�
    //public Vector3 offset;

    public float speed = 1;
    public float follow_distance = 10f;

    private float cooldown = 2f;

    public GameObject mesh;
    public GameObject bullet;

    public float health = 100f;

    public GameObject death_effect;

    public AudioClip death_sound;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }
    private void FollowPlayer()
    {
        //Look to player
        //Drone'un karakterimize bakmas�
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(-90, 0, 0));

        //Move to player
        //Drone'un karakterimize do�ru hareket etmesi
        //Drone Follow distance'ye kadar bize yakla��r. Follow distanceye gelince karakterimizin etraf�nda d�ner.
        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed * -1);
        }

        else
        {
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed * Random.Range(0.2f, 3f));
        }
    }

    //Drone 2 (Cooldown) saniyede bir karakterimize ate� eder. 
    private void Shot()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;

            //Shot
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(-90, 0, 0)));
        }
    }
    private void Death()
    {
        if (health <= 0)
        {
            //Spawn particle. Drone patlay�nca partik�ller sa��ls�n.
            Instantiate(death_effect, transform.position, Quaternion.identity);

            //Play sound effect
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sound);

            //Destroy gameobject. Drone'u patlat.
            Destroy(this.gameObject);
        }
    }
}