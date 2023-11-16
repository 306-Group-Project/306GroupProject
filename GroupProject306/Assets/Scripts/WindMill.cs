using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    [SerializeField] public float health = 100.0f;
    public GameManager manager;
    public GameObject healthbar;

    private WaitForSeconds pause;
    private bool isAnimating = false;

    // Start is called before the first frame update
    void Awake()
    {
        pause = new WaitForSeconds(0.04f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // moved destroy to enemy script, to ensure damage is counted to windmill, then enemy is destroyed

    public void TakeDamge(float damage)
    {
        health -= damage;
        healthbar.GetComponent<WindMillHealth>().SetHealth(health);  
    }
    // returns current hp
    public float getHp()
    {
        return health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isAnimating == false && other.gameObject.tag=="Enemy")
        {
            if (gameObject.transform.position.x < other.gameObject.transform.position.x)
            {
                StartCoroutine(ShakeRight());
            }
            else
            {
                StartCoroutine(ShakeLeft());
            }
        }
    }

    private IEnumerator ShakeLeft()
    {
        isAnimating = true;

        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.Rotate(0f, 0f, 2f);

            yield return pause;
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.Rotate(0f, 0f, -2f);

            yield return pause;
        }

        gameObject.transform.Rotate(0f, 0f, 2f);

        yield return pause;

        isAnimating = false;
    }

    private IEnumerator ShakeRight()
    {
        isAnimating = true;

        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.Rotate(0f, 0f, -2f);

            yield return pause;
        }

        for (int i = 0; i < 5; i++)
        {
            gameObject.transform.Rotate(0f, 0f, 2f);

            yield return pause;
        }

        gameObject.transform.Rotate(0f, 0f, -2f);

        yield return pause;

        isAnimating = false;
    }


}
