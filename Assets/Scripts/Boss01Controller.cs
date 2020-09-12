using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01Controller : MonoBehaviour
{
    public GameObject explosion;

    public float animationSpeed = 0.5f;

    public int bossLife = 5000;

    public int hitDamage = 5;

    public GameObject enemyBala;

    public GameObject EnemyController;

    public bool firing = false;

    private float timeUpdate = 0.5f;
    private float second = 1;

    public float intervalTime = 0.5f;

    private bool direcionalFireOn = false;

    private int bossFightingTime = 0;
    private int fightCounter = 0;

    public int newAction = 0;

    public Animator bossAttack;

    private bool bossActive = false;

    private int inAction = 0;

    public GameObject Player;

    public AudioSource mainBg;

    public AudioSource bossBg;

    void Start() {
        Player.GetComponent<shipContol>().releasedControls = false;
        mainBg.Stop();
        bossBg.Play();
        EnemyController.GetComponent<EnemyController>().canRenderEnemies = false;
        Player.GetComponent<shipContol>().fireing = false;
        foreach (GameObject enemie in GameObject.FindGameObjectsWithTag("Inimigo") ){
            Destroy(enemie);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > 4.5) {
            transform.Translate(new Vector2(0, -1f * Time.deltaTime));
            
        } else {
            bossActive = true;
            if (Player != null) {
                Player.GetComponent<shipContol>().releasedControls = true;
                
            }
        }

        if (bossActive){ 
            // Tudo que colocar aqui vai acontecer dentro do intervalo de tempo
            if ( firing ) {
                if ( Time.time >= timeUpdate ) {
                    Instantiate(enemyBala, new Vector3(transform.position.x - 4.5f, transform.position.y + 1.5f   , 0), Quaternion.identity);
                    Instantiate(enemyBala, new Vector3(transform.position.x - -4.7f, transform.position.y + 1.5f   , 0), Quaternion.identity);
                    timeUpdate = Time.time + intervalTime;
                }
            } else {
                timeUpdate = intervalTime;
            }

            if ( Time.time >= bossFightingTime ) {
                if (fightCounter >= 7) {
                    inAction = generateRandom(0, 3);
                    fightCounter = 0;
                }
                fightCounter++;
                bossFightingTime = Mathf.FloorToInt(Time.time) + 1;
            }

            if (inAction == 0){
                bossAttack.SetBool("bossAttacking", false);
                bossAttackStyle02();
            }

            if (inAction == 1){
                bossAttack.SetBool("bossAttacking", false);
                bossAttackStyle01();
            }

            if (inAction == 2){
                 bossAttack.SetBool("bossAttacking", true);
                bossAttackStyle03();
            }

        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if ( other.gameObject.tag == "Bala" ) {
            if ( bossLife > 0 ) {
                bossLife -= hitDamage;
            } else {
               showBossDestruction();
            }
            Instantiate(explosion, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity);
        }
    }

    private void showBossDestruction(){
        if (gameObject != null)  {
            Destroy(gameObject);
            bossBg.Stop();
            mainBg.Play();
            EnemyController.GetComponent<EnemyController>().canRenderEnemies = true;
        }
    }

    private void bossAttackStyle01(){
        direcionalFireOn = false;
        if (firing == false) {
            if (transform.position.x > -11f) {
                transform.Translate(new Vector2( -animationSpeed * Time.deltaTime, 0 ));
            } else {
                firing = true;
            }
        }
        if (firing) {
            if (transform.position.x < 8.45f) {
                transform.Translate(new Vector2( +animationSpeed * Time.deltaTime, 0 ));
            } else{
                firing = false;
            }
        }
    }

    private void bossAttackStyle02(){
        direcionalFireOn = false;
        if (firing == false) {
            if (transform.position.x < 12f) {
                transform.Translate(new Vector2( +animationSpeed * Time.deltaTime, 0 ));
            } else {
                firing = true;
            }
        }
        if (firing) {
            if (transform.position.x > -8.45f) {
                transform.Translate(new Vector2( -animationSpeed * Time.deltaTime, 0 ));
            } else{
                firing = false;
            }
        }
    }

    private void bossAttackStyle03(){
        firing = false;
        if (firing == false) {
            if (transform.position.x < 0f) {
                transform.Translate(new Vector2( +animationSpeed * Time.deltaTime, 0 ));
            }
            if (transform.position.x > 0f) {
                transform.Translate(new Vector2( -animationSpeed * Time.deltaTime, 0 ));
            } 
            
            if (transform.position.x > -1f && transform.position.x < 1f) {
                bossAttack.SetBool("bossAttacking", true);
                direcionalFireOn = true;
            }
        }
    }

    private int generateRandom(int min, int max)
    {
        System.Random random = new System.Random();
        int action = inAction;
        while(action == inAction) {
            action = random.Next(min, max);
        }
        return action; 
    }

}
