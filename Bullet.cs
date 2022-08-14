using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;

    //At�lan mermilerin silinmesi i�in
    public float lifetime = 5f;

    public bool enemy_bullet = false;
    public float bullet_radius = 0.5f;
    public LayerMask player_layer;

    public GameObject hit_effect;

    public AudioClip hit_sound;


    private void Update()
    {
        transform.Translate(Vector3.forward * -1 * Time.deltaTime * speed);

        lifetime -= Time.deltaTime;

        //5 saniye i�inde mermileri ortadan kald�r.
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        //Enemy bullet. Drone'un bize att��� mermi.
        //Unity aray�z�nde enemy_bullet tikini i�aretlemeliyiz.
        if (enemy_bullet)
        {
            if (Physics.CheckSphere(transform.position, bullet_radius, player_layer))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //E�er drone'u vurursak.
        //if hit to enemy
        if (other.CompareTag("Enemy"))
        {
            GameObject drone = other.transform.parent.gameObject;

            //Drone her mermi yedi�inde can� 25 azals�n.
            drone.GetComponent<Drone>().health -= 25f;

            //Drone vurulma efekti �al.
            drone.GetComponent<AudioSource>().PlayOneShot(hit_sound);

        }
        //Hit
        Instantiate(hit_effect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}




