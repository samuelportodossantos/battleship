using UnityEngine;
using UnityEngine.UI;

public class enemyControl : MonoBehaviour
{
    public GameObject enemy;
    public AudioSource enemyExplosion;
    private float enemySpeed = 1f;
    EnemyController enemyController;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        enemyExplosion = GameObject.FindGameObjectWithTag("Boom").GetComponent<AudioSource>();
        this.enemySpeed = this.generateRandom(3f, 6f);
        this.enemyController =  GameObject.FindGameObjectWithTag("Score").GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -this.enemySpeed * Time.deltaTime, 0));

        if ( transform.position.y <= -10f )
        {
            if (this.enemyController.scoreFactor > 51)
            {
                this.enemyController.scoreFactor -= 50;
            }
            Destroy(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bala")
        {

            GameObject[] projeteis = GameObject.FindGameObjectsWithTag("Bala");
            foreach (GameObject bala in projeteis)
            {
                Destroy(bala);
            }


            this.enemyExplosion.Play();
            

            Text scoreText = this.enemyController.txt;
            this.enemyController.defeatedEnemies += enemyController.scoreFactor;
            scoreText.text = "SCORE: "+ enemyController.defeatedEnemies;
            
            if ( PlayerPrefs.GetInt("score") < this.enemyController.defeatedEnemies )
            {
                PlayerPrefs.SetInt("score", this.enemyController.defeatedEnemies);
            }

            Destroy(enemy);
            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        }
    }

    private float generateRandom(float min, float max)
    {
        return Random.Range(min, max);
    }

}
