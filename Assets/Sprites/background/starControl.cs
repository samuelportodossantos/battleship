using UnityEngine;

public class starControl : MonoBehaviour
{

    public float starSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.starSpeed = this.generateRandom(10f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -this.starSpeed * Time.deltaTime));

        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }

    private float generateRandom(float min, float max)
    {
        return Random.Range(min, max);
    }
}
