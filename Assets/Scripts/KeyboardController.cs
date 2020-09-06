using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{

    public float ObjectSpeed;

    private bool movingUp;
    private bool movingDown;
    private bool movingRight;
    private bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Liberando movimento pra esquerda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movingLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            movingLeft = false;
        }

        //Liberando movimento pra direita
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            movingRight = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            movingRight = false;
        }

        //Liberando movimento pra cima
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movingUp = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            movingUp = false;
        }

        // Liberando movimento pra baixo
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            movingDown = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            movingDown = false;
        }


        if (movingRight)
        {
            transform.Translate(new Vector3(ObjectSpeed * Time.deltaTime, 0, 0));
        }

        if (movingLeft)
        {
            transform.Translate(new Vector3(-ObjectSpeed * Time.deltaTime, 0, 0));
        }

        if (movingUp)
        {
            transform.Translate(new Vector3(0, ObjectSpeed * Time.deltaTime, 0));
        }

        if (movingDown)
        {
            transform.Translate(new Vector3(0, -ObjectSpeed * Time.deltaTime, 0));
        }

    }

   
}
