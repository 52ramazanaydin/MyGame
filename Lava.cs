
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // if Player fall to Lava. Karakterimiz lava düþerse
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerManager>().Death();
        }

    }

}
