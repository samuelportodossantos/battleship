using UnityEngine;

public class shipContol : MonoBehaviour
{
    public float shipSpeed = 15;
    public bool releasedControls = true;
    public bool doubleShot = false;
    public bool quadShot = false;

    public GameObject explosion;
    public GameObject gameOver;
    Joystick Joy;

    public bool fireing = false;
    public GameObject bala;
    public AudioSource fireSong;
    public AudioSource gameOverSong;
    public AudioSource bgSong;
    public GameObject menu;
    public AudioSource gameOverVoice;
    public AudioSource getBonusVoice;
    public GameObject bonusTimerController;
    public GameObject starControl;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Joy = FindObjectOfType<Joystick>();
    }

    public void setFiring()
    {
        this.fireing = true;
    }

    public void notFiring()
    {
        this.fireing = false;
    }

    // Update is called once per frame
    void Update()
    {

       
        if (this.releasedControls)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                fireing = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                fireing = false;
            }

            if (Joy.Direction.y < 0) {
                animator.SetBool("moving_up", false);
            } else {
                animator.SetBool("moving_up", true);
            }

            gameObject.GetComponent<Transform>().localPosition += new Vector3((Joy.Horizontal * this.shipSpeed) * Time.deltaTime, (Joy.Vertical * this.shipSpeed) * Time.deltaTime, 0);

            if ( this.fireing ) {
                if (GameObject.FindGameObjectsWithTag("Bala").Length <= 10)
                {

                    if (this.doubleShot)
                    {
                        Instantiate(bala, new Vector3((transform.position.x - 0.3f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                        Instantiate(bala, new Vector3((transform.position.x - -0.3f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                        
                    } else if(this.quadShot) {

                        Instantiate(bala, new Vector3((transform.position.x - 0.3f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                        Instantiate(bala, new Vector3((transform.position.x - -0.3f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);

                        Instantiate(bala, new Vector3((transform.position.x - 0.9f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                        Instantiate(bala, new Vector3((transform.position.x - -0.9f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);

                    } else
                    {
                        Instantiate(bala, new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                    }
                    
                    this.fireSong.Play();
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo" || collision.gameObject.tag == "BalaInimigo")
        {

            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);

            gameOver.SetActive(true);
            bgSong.Stop();
            gameOverSong.Play();
            gameOverVoice.Play();
            menu.SetActive(false);

        }

        if (collision.gameObject.tag == "TiroDuplo")
        {
            this.doubleShot = true;
            this.quadShot = false;
            getBonusVoice.Play();
            Destroy(collision.gameObject);
            initBonusTimer();
        }

        if (collision.gameObject.tag == "TiroQuadruplo")
        {
            this.doubleShot = false;
            this.quadShot = true;
            getBonusVoice.Play();
            Destroy(collision.gameObject);
            initBonusTimer();
        }
    }

    void initBonusTimer()
    {
        bonusTimerController.GetComponent<decreaseTime>().resetCurrentTime();
        bonusTimerController.SetActive(true);
    }
}

