using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject windMill;

    public Text scoreText;
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
        inMenu = true;
        SetScoreText();
        SetLevelText();
        Time.timeScale = 0;
    }

    private void Update()
    {
        // making sure player cant have pause and shop screen open at once
        if (!inMenu && !isPaused)
        {
            PauseGame();
        }
        
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        inMenu = false;
        startMenu.SetActive(false);
        gameScreen.SetActive(true);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetLevelText()
    {
        levelText.text = "Level: " + level.ToString();
    }



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
        pauseMenu.SetActive(false);
        shopMenu.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.P) && !isPaused && !inMenu)
        {
            gameScreen.SetActive(false);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
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
    }
    
    public void OpenDefenceMenu()
    {
        shopMenu.SetActive(false);
        defenceMenu.SetActive(true);
    }

    public void OpenUpgradeMenu()
    {
        shopMenu.SetActive(false);
        upgradeMenu.SetActive(true);
    }
    
    public void OpenOffenceMenu()
    {
        shopMenu.SetActive(false);
        offenceMenu.SetActive(true);
    }

    public void EndGame()
    {
        gameScreen.SetActive(false);
        endGameScreen.SetActive(true);
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
