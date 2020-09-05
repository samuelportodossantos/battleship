using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControll : MonoBehaviour
{

    public GameObject star;
    public int amountOfStars = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("star").Length <= 100)
        {
            this.renderStars();
        }
    }

    private void renderStars()
    {
        for (int i = 0; i < amountOfStars; i++)
        {
            Instantiate(this.star, new Vector3(this.generateRandom(-18f, 18f), this.generateRandom(-8f, 30f), 0), Quaternion.identity);
        }
    }

    private float generateRandom(float min, float max)
    {
        return Random.Range(min, max);
    }
}
