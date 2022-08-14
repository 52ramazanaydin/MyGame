using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;

    //Atýlan mermilerin silinmesi için
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

        //5 saniye içinde mermileri ortadan kaldýr.
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        //Enemy bullet. Drone'un bize attýðý mermi.
        //Unity arayüzünde enemy_bullet tikini iþaretlemeliyiz.
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

        //Eðer drone'u vurursak.
        //if hit to enemy
        if (other.CompareTag("Enemy"))
        {
            GameObject drone = other.transform.parent.gameObject;

            //Drone her mermi yediðinde caný 25 azalsýn.
            drone.GetComponent<Drone>().health -= 25f;

            //Drone vurulma efekti çal.
            drone.GetComponent<AudioSource>().PlayOneShot(hit_sound);

        }
        //Hit
        Instantiate(hit_effect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}




