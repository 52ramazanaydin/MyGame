using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    //Karakterimizin kolonda ayaðýnýn temas ettiði üst yüzey.
    public Transform checker;

    public LayerMask player_layer;
    public float radius = 5;

    private Vector3 velocity;

    private bool broke = false;
    private void Update()
    {
        //Karakterimiz kolona basýnca (broke = true), kolon yavaþça aþaðý doðru hareket eder.

        if (Physics.CheckBox(checker.position, new Vector3(radius, 2, radius), Quaternion.identity, player_layer))
        {
            broke = true;

        }
        if (broke)
        {
            velocity.z -= Time.deltaTime / 200;
            transform.Translate(velocity);
        }
    }


}