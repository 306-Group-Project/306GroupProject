using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject player;

    public Text scoreText;
    [SerializeField] private int score = 0;

    [SerializeField] private float windMillHealth = 100.0f;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject startMenu;
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
        SetScoreText();
        Time.timeScale = 0;
    }

    private void Update()
    {
        PauseGame();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startMenu.SetActive(false);
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
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
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.P) && !isPaused)
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
        }
    }
}
