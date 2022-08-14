
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask obstacle, player_layer;

    public float laser_multiplier = 1;

    public GameObject death_effect;

    public bool laser_hit;

    public float range = 100f;

    private void Update()
    {
        //Line Renderer. Lazer görümünü üretir.
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            laser_hit = true;

            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            //Time.time sürekli artan bir sayaç
            //Mathf.Sin sinüs fonksiyonu
            GetComponent<LineRenderer>().startWidth = 0.025f * laser_multiplier + Mathf.Sin(Time.time) / 80;

        }

        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laser_hit = false;
        }

        //Kill Player
        // Lazer karakterimize deðince karakterimiz ölür.
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, player_layer))
        {
            if (laser_hit)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<PlayerManager>().Death();
                }

            }

        }
    }

}
