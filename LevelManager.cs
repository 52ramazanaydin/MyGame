
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Player enter - exit.
    //Karakterimizin levele baþlayýp - leveli bitimesi
    public bool player_enter, player_exit;

    //Spawn
    private bool spawned = false;
    public Transform[] drone_spawners;
    public GameObject drone;

    //Level Spawn
    public GameObject level;
    public GameObject destroy_level;


    private void Awake()
    {
        player_enter = false;
        spawned = false;
    }
    private void Update()
    {
        //Spawn
        if (!spawned)
        {
            if (player_enter)
            {
                //Drone Spawn
                for (int i = 0; i < drone_spawners.Length; i++)
                {
                    Instantiate(drone, drone_spawners[i].position, Quaternion.identity);
                }

                //Level Spawn
                SpawnLevel();

                //Set Boolean
                spawned = true;
            }



        }

        //Destroy Level
        if (player_exit)
        {
            if (destroy_level != null)
            {
                Destroy(destroy_level);
            }

        }
    }

    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 120);
        //Instantiate, obje oluþturulur.
        GameObject obj = Instantiate(level, pos, Quaternion.identity);

        //Bir sonraki levelin exitine gelince, bir önceki leveli ortadan kaldýrýr.
        obj.GetComponent<LevelManager>().destroy_level = this.gameObject;

    }


}
