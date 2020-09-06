using System;
using UnityEngine;

public class StarControll : MonoBehaviour
{

    public GameObject Player;
    public GameObject star;
    public GameObject doubleShot;
    public GameObject quadShot;

    public int amountOfStars = 25;
    public int doubleShotsItems = 3;
    public int quadShotsItems = 1;

    public int currentTime = 0;
    public int nextUpdate = 1;

    private int bonusRenderTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        generateBonusRenderTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("star").Length <= 100)
        {
            this.renderStars();
        }

        if (Time.time >= nextUpdate)
        {
            currentTime++;
            if (currentTime > bonusRenderTime)
            {
                renderBonus();
            }
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
        }
    }

    private void renderBonus()
    {
        if (Player != null)
        {
            if (Player.GetComponent<shipContol>().doubleShot == false && Player.GetComponent<shipContol>().quadShot == false)
            {
                if (generateRandom(1f, 10f) >= 5)
                {
                    Instantiate(this.doubleShot, new Vector3(this.generateRandom(-12f, 12f), this.generateRandom(20f, 30f), 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(this.quadShot, new Vector3(this.generateRandom(-12f, 12f), this.generateRandom(20f, 30f), 0), Quaternion.identity);
                }

                generateBonusRenderTime();
            }
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
        return UnityEngine.Random.Range(min, max);
    }

    private void generateBonusRenderTime()
    {
        bonusRenderTime = currentTime + (int)Math.Round(generateRandom(30f, 60f));
        print("Próximo bonus em " + bonusRenderTime + " segundos");
    }
}
