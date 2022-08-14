
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager lm;
    public bool enter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (enter)
            {
                lm.player_enter = true;
            }

            else
            {
                lm.player_exit = true;
            }

        }

    }
}
