using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // windmill items
    public WindMill windMill;
    public GameObject windmillObject;
    public GameObject smoke;
    private Transform windmillLocation;
    public AudioScript audioScript;

    public Text scoreText, defenceScoreText, upgradeScoreText, offenceScoreText;

    public Text levelText;
    public Text highScoreText, gameOverHighScore, gameOverCurrentScore;
    [SerializeField] private int score = 0;
    [SerializeField] private int level = 1;

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
    public GameObject Coins; 
    [SerializeField] private bool inMenu;
    [SerializeField] private bool isPaused;

	// Text Screen Add Ons 
	[SerializeField] private GameObject textScreenFolder; 

	[SerializeField] private GameObject levelNumScreen; 
    public Text levelFadeText;

	[SerializeField] private GameObject openShopTextScreen;
	[SerializeField] private GameObject useShopTextScreen;
	[SerializeField] private GameObject waveTextScreen;
	[SerializeField] public GameObject coinInstructionScreen;
	[SerializeField] private GameObject coinTipsScreen;

    public int enemyKills = 0;
    
    // Level Manager object
    public GameObject levelManager;
    
    public float screenDuration = 0.5f; // Duration of the screen in seconds
    

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
            //Debug.DrawRay(ray.origin, ray.direction * 10,Color.red,3f);
    		
            if (Physics.Raycast(ray, out hit,1000f,mask,QueryTriggerInteraction.Collide))
            {
                if (hit.collider != null && hit.collider.CompareTag("Coin"))
                {
                    CollectCoin(hit.collider.gameObject);
                }
            }
        }    
    }

    // collection for single coins 
    void CollectCoin(GameObject coin)
    {
        // Destroy the collected coin GameObject
        audioScript.playCoinSound();
        Destroy(coin);
        coinInstructionScreen.SetActive(false);
        score += 1;
        SetScoreText();
    }
    
    // collection for stacks of coins 
    void CollectCoins(GameObject coins)
    {
        // Destroy the collected coin GameObject
        audioScript.playCoinSound();
        Destroy(coins);
        score += 5;
        SetScoreText();
    }

    public void increaseEnemyKill()
    {
        enemyKills += 1;
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
                audioScript.playWindmillDestroyed();
                Destroy(cloud, 0.5f);
                Invoke("EndGame", (float)0.75);
            }
        }
    }
    
    IEnumerator DeactivateScreenAfterDelay()
    {
        yield return new WaitForSeconds(screenDuration);
        openShopTextScreen.SetActive(false);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        inMenu = false;
        startMenu.SetActive(false);
        audioScript.playMenuSwitch();

        gameScreen.SetActive(true);

		textScreenFolder.SetActive(true); 
        
        openShopTextScreen.SetActive(true); 
        StartCoroutine(DeactivateScreenAfterDelay());
			 
   		}

    public void SetScoreText()
    {
        scoreText.text = "Coins: " + score.ToString();
        defenceScoreText.text = "Coins: " + score.ToString();
        upgradeScoreText.text = "Coins: " + score.ToString();
        offenceScoreText.text = "Coins: " + score.ToString();
    }

    public void SetHighScore(int maxKills)
    {
        highScoreText.text = "High Score: " + maxKills.ToString();
        gameOverHighScore.text = "High Score: " + maxKills.ToString();
    }

    public void SetLevelText(int levelCount)
    {
        levelText.text = "Level: " + levelCount.ToString();
    	levelFadeText.text = "Level " + levelCount.ToString(); //testing
    }

    public int getScore() { return score; }
    
    public void AddPoints(int scoreToAdd)
    {
        score += scoreToAdd;
        SetScoreText();
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
        audioScript.playMenuSwitch();
        pauseMenu.SetActive(false);
        shopMenu.SetActive(false);
        gameScreen.SetActive(true);
		useShopTextScreen.SetActive(false);

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
    
    public void OpenShopMenu()
    {
        int level = levelManager.GetComponent<LevelSystem>().getLevel();
        
        openShopTextScreen.SetActive(false);
        inMenu = true;
        Time.timeScale = 0;
        shopMenu.SetActive(true);	
		defenceMenu.SetActive(false);
        upgradeMenu.SetActive(false);
        offenceMenu.SetActive(false);
        gameScreen.SetActive(false);
        audioScript.playMenuSwitch();
        
		if(level == 1){ 
			useShopTextScreen.SetActive(true); // TODO add if statment for level 1 only 
		}
		else if (level != 1){
			useShopTextScreen.SetActive(false);  
		}
    }
    
    public void OpenDefenceMenu()
    {
        shopMenu.SetActive(false);
		useShopTextScreen.SetActive(false);
        defenceMenu.SetActive(true);
        audioScript.playMenuSwitch();
    }

    public void OpenUpgradeMenu()
    {
        shopMenu.SetActive(false);
		useShopTextScreen.SetActive(false);
        upgradeMenu.SetActive(true);
        audioScript.playMenuSwitch();
    }
    
    public void OpenOffenceMenu()
    {
        shopMenu.SetActive(false);
		useShopTextScreen.SetActive(false);
        offenceMenu.SetActive(true);
        audioScript.playMenuSwitch();
    }

    

    public void EndGame()
    {
        gameScreen.SetActive(false);
        endGameScreen.SetActive(true);
        Time.timeScale = 0;
        gameOverCurrentScore.text = "Current Score: " + enemyKills.ToString();

        if (PlayerPrefs.GetInt("MaxEnemyKills", 0) < enemyKills)
        {
            PlayerPrefs.SetInt("MaxEnemyKills", enemyKills);
        }
    }
}
