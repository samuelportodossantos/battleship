using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -0.1f, 0));


        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
}
