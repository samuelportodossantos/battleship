using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public Text txt;
    public Text BestScore;

    private double amountOfEnemies = 2;
    public int defeatedEnemies = 0;
    public int scoreFactor = 200;

    // Start is called before the first frame update
    void Start()
    {
        this.amountOfEnemies = 10;
        this.BestScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("score");
        this.renderEnemies();

    }

    // Update is called once per frame
    void Update()
    {

        if ( GameObject.FindGameObjectsWithTag("Inimigo").Length <= 0)
        {
           
            this.renderEnemies();
            //this.player.GetComponent<shipContol>().doubleShot = true;
        }
        
    }

    public void renderEnemies()
    {

        for (int i = 0; i < this.amountOfEnemies; i++)
        {
            Instantiate(enemy, new Vector3(this.generateRandom(-10f, 10f), this.generateRandom(10f, 30f), 0), Quaternion.identity);
        }
       
    }

    private float generateRandom(float min, float max)
    {
        return Random.Range(min, max);
    }

}
