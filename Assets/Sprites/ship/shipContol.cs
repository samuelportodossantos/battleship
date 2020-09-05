using UnityEngine;

public class shipContol : MonoBehaviour
{
    public float shipSpeed = 0.001f;
    private bool releasedControls = true;
    public bool doubleShot = false;
    public GameObject explosion;
    public GameObject gameOver;
    Joystick Joy;

    public bool fireing = false;
    public GameObject bala;
    public AudioSource fireSong;
    public AudioSource gameOverSong;
    public AudioSource bgSong;
    public GameObject menu;
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        //this.doubleShot = true;
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

            gameObject.GetComponent<Transform>().localPosition += new Vector3((Joy.Horizontal * this.shipSpeed) * Time.deltaTime, (Joy.Vertical * this.shipSpeed) * Time.deltaTime, 0);

            if ( this.fireing ) {
                if (GameObject.FindGameObjectsWithTag("Bala").Length <= 10)
                {

                    if (this.doubleShot)
                    {
                        Instantiate(bala, new Vector3((transform.position.x - 0.3f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                        Instantiate(bala, new Vector3((transform.position.x - -0.3f), (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                        
                    } else {
                        Instantiate(bala, new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                    }
                    
                    this.fireSong.Play();
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {

            Instantiate(explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);

            gameOver.SetActive(true);
            bgSong.Stop();
            gameOverSong.Play();
            pause.SetActive(false);
            menu.SetActive(false);

        }
    }
}
