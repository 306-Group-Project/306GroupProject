using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public AudioScript audioScript;

    // windmill items
    public WindMill windMill;
    public GameObject windmillObject;
    public GameObject smoke;
    private Transform windmillLocation;
    private AudioSource windmillDestroyedSound;

    public Text scoreText;

    public Text defenceScoreText;
    public Text upgradeScoreText;
    public Text offenceScoreText;
    public Text gameOverScreenScore;

    public Text levelText;

    [SerializeField] private int score = 0;
    [SerializeField] private int level = 0;

    [SerializeField] private float windMillHealth = 100.0f;

    [SerializeField] private Camera camera;

    // Menus
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject defenceMenu;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject offenceMenu;
     public GameObject Coin;
    [SerializeField] private bool inMenu;
    [SerializeField] private bool isPaused;


    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        windmillDestroyedSound = GetComponent<AudioSource>();
        SetHighScore(PlayerPrefs.GetInt("MaxEnemyKills", 0));
        inMenu = true;
        SetScoreText();
        SetLevelText(level);
        Time.timeScale = 0;
    }

    private void Update()
    {
        // making sure player cant have pause and shop screen open at once
        if (!inMenu && !isPaused)
        {
            PauseGame();
        }
        checkWindMillHealth();
if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for interaction
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
			LayerMask mask = LayerMask.GetMask("Coin");
           Debug.DrawRay(ray.origin, ray.direction * 10,Color.red,3f);

            if (Physics.Raycast(ray, out hit,1000f,mask,QueryTriggerInteraction.Collide))
            {
                Debug.Log("Hit");
                if (hit.collider != null && hit.collider.CompareTag("Coin"))
                {
                    CollectCoin(hit.collider.gameObject);
                }
            }
        }


void CollectCoin(GameObject coin)
    {


        // Destroy the collected coin GameObject
        Destroy(coin);
        score+=1;
        SetScoreText();
        audioScript.playCoinSound();
    }


    }



    public void checkWindMillHealth()
    {
        if (windMill)
        {
            if (windMill.getHp() <= 0)
            {
                if (!windmillLocation)
                {
                    windmillLocation = windmillObject.transform;
                }

                GameObject cloud = Instantiate(smoke, windmillLocation.position, transform.rotation);
                Destroy(windmillObject);
                windmillDestroyedSound.Play();
                Destroy(cloud, 0.5f);
                Invoke("EndGame", (float)0.75);
            }
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        inMenu = false;
        startMenu.SetActive(false);
        gameScreen.SetActive(true);
        audioScript.playMenuSwitch();
    }

    public void SetScoreText()
    {
        scoreText.text = "Coins: " + score.ToString();
        defenceScoreText.text = "Coins: " + score.ToString();
        upgradeScoreText.text = "Coins: " + score.ToString();
        offenceScoreText.text = "Coins: " + score.ToString();
        gameOverScreenScore.text = "Score: " + score.ToString();
    }

    public void SetHighScore(int maxKills)
    {
        upgradeScoreText.text = "High Score: " + maxKills.ToString();
        gameOverScreenScore.text = "High Score: " + maxKills.ToString();
    }

    public void SetLevelText(int levelCount)
    {
        levelText.text = "Level: " + levelCount.ToString();
    }

    public void AddPoints(int scoreToAdd)
    {
        score += scoreToAdd;
        SetScoreText();
    }

    public int getScore()
    {
        return score;
    }


    public float getWindMillHealth()
    {
        return windMillHealth;
    }

    public void setWindMillHealth(float newHealth)
    {
        this.windMillHealth = newHealth;
    }

    public void ResumeGame()
    {
        inMenu = false;
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        shopMenu.SetActive(false);
        gameScreen.SetActive(true);
        audioScript.playMenuSwitch();

    }

    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.P) && !isPaused && !inMenu)
        {
            gameScreen.SetActive(false);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
            audioScript.playMenuSwitch();
        }

    }

    // set the shop menu to open on B button press, will change later
    public void OpenShopMenu()
    {
        inMenu = true;
        Time.timeScale = 0;
        shopMenu.SetActive(true);
        defenceMenu.SetActive(false);
        upgradeMenu.SetActive(false);
        offenceMenu.SetActive(false);
        gameScreen.SetActive(false);
        audioScript.playMenuSwitch();

    }

    public void OpenDefenceMenu()
    {
        shopMenu.SetActive(false);
        defenceMenu.SetActive(true);
        audioScript.playMenuSwitch();

    }

    public void OpenUpgradeMenu()
    {
        shopMenu.SetActive(false);
        upgradeMenu.SetActive(true);
        audioScript.playMenuSwitch();

    }

    public void OpenOffenceMenu()
    {
        shopMenu.SetActive(false);
        offenceMenu.SetActive(true);
        audioScript.playMenuSwitch();

    }

    public void EndGame()
    {
        gameScreen.SetActive(false);
        endGameScreen.SetActive(true);
        Time.timeScale = 0;
        windmillDestroyedSound.Play();

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        audioScript.playMenuSwitch();

    }
}
