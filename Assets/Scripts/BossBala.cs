using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBala : MonoBehaviour
{

    public float speed;
    public bool teleguiado = false;

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y < - 10f ) {
            Destroy(gameObject);
        }

        transform.Translate( new Vector3(0 * Time.deltaTime, -speed * Time.deltaTime, 0) );
    }
}
